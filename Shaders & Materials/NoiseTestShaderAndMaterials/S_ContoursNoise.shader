Shader "NoiseCreater/ContoursNoise_Test"
{
    Properties
    {
        _a1("a1", float) = 0.5
        _b1("b1", float) = 0.5
        _c1("c1", float) = 0.5
        _d1("d1", Range(1,25)) = 1//模糊值
        _e1("e1", float) = 0.5
        _f1("f1", Range(-1,20)) = 0.5 //边缘线亮度
        _g1("g1", float) = 0.5

        _ns("ns", float) = 0

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

             float _a1;
             float _b1;
             float _c1;
             float _d1;
             float _e1;
             float _f1;
             float _g1;

             float _ns;
//--------------------------------------------------------

            float sFrac(float x, float sm)
            {
                float sf = 1;
                //float2 u = float2(x, (ddx(x)+ddy(x))* sf* sm);
                float2 u = float2(x, fwidth(x)* _c1* sm);//c1 等高线分界线偏移

                u.x = frac(u.x);
                u += (_d1 - 2* u)* step(u.y, u.x);//_d1 模糊值，默认为 1
                return clamp(1 - u.x/u.y, 0, 1);
            }
            float sFloor(float x)
            {
                //return x - sFrac(x, 1);
                return x - sFrac(x, 1);
            }
            //float3 rotHue(float3 p, float a)
            //{
            //    //float2 cs = sin(float2(_e1, 0) + a);
            //    float3x3 hr = float3x3(float3(0.299, 0.587, 0.114), float3(0.299,  0.587,  0.114), float3(0.299,  0.587,  0.114)) + 
            //                  float3x3(float3(0.701, -0.587, -0.114), float3(-0.299,  0.413, -0.114), float3(-0.300, -0.588,  0.886)) +// * cs.x + 
            //                  float3x3(float3(0.168,  0.330, -0.497), float3(-0.328,  0.035,  0.292), float3(1.250, -1.050, -0.203)); // * cs.y;
            //    return clamp(mul(p, hr), 0, 1);
            //}
            float3 hash33(float3 p)
            {
                float n = sin(dot(p, float3(7, 157, 113)));
                return frac(float3(2097152, 262144, 32768) * n) * 2 - 1;
            }
            float tetraNoise(float3 p)
            {
                float3 i = floor(p + dot(p, float3(1/3, 1/3, 1/3)));
                p -= i - dot(i, float3(1/6, 1/6, 1/6));
                float3 i1 = step(p.yzx, p);
                float3 i2 = max(i1, 1 - i1.zxy);
                i1 = min(i1, 1 - i1.zxy);
                float3 p1 = p - i1 + 1/6;
                float3 p2 = p - i2 + 1/3;
                float3 p3 = p - 0.5;
                float4 v = max(0.5 - float4(dot(p, p), dot(p1, p1), dot(p2, p2), dot(p3, p3)), 0);
                float4 d = float4(dot(p, hash33(i)), dot(p1, hash33(i + i1)), dot(p2, hash33(i + i2)), dot(p3, hash33(i + 1)));
                return clamp(dot(d, v*v*v*8)*1.732 + 0.5, 0, 1);
            }
            float func(float2 p)
            {
                float n = tetraNoise(float3(p.x*4, p.y*4, 0) - float3(0, 0.25, 0.5)*_g1);//_g1 形态变化
                float taper = 0.1 + dot(p, p* float2(0.35, 1));
                n = max(n - taper, 0)/max(1 - taper, 0.001);
                _ns = n;
                float palNum = 9;
                return (n*0.25 + clamp(sFloor(n* (palNum - 0.001))/(palNum - 1), 0, 1) * 0.75);
            }
//--------------------------------------------------------
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //fixed4 col = fixed4(1,0.5,1,1);
                //float2 uv = (i.uv * 2 - 1);
                float2 uv = (float2(i.uv.y*4-2, i.uv.x*3-1.5))/4;
                //uv = uv * _b1;
                //float2 uv = i.uv/_ScreenParams.y;
                //float2 uv = (i.uv - _ScreenParams.xy * 0.5);//_ScreenParams.y;
                //float2 uv = i.uv/_ScreenParams.xy;

                float contoursNoise_f = func(uv);
                float contoursNoise_ssd = _ns;

                float2 contoursNoise_e = float2(1.5/_ScreenParams.y, 0);
                float contoursNoise_fxl = func(uv + contoursNoise_e.xy);
                float contoursNoise_fxr = func(uv - contoursNoise_e.xy);
                float contoursNoise_fyt = func(uv + contoursNoise_e.yx);
                float contoursNoise_fyb = func(uv - contoursNoise_e.yx);

                fixed3 col = pow(min( float3(1.5, 1, 1)*(contoursNoise_f * 0.7 + contoursNoise_ssd * 0.35), 1), float3(1, 2, 10)*2) + 0.1;
                //fixed3 col = float3(0.5, 0.5, 0.5);
                //col = rotHue(col, -0.25 + 4 * length(uv));
                col *= max(1 - (abs(contoursNoise_fxl - contoursNoise_fxr) + abs(contoursNoise_fyt - contoursNoise_fyb))* 5, 0);//5 边界清晰度
                contoursNoise_fxl = func(uv + contoursNoise_e.xy* 1.5);
                contoursNoise_fxr = func(uv + contoursNoise_e.xy* 1.5);
                //col += float3(0.5, 0.7, 1)* (max(contoursNoise_f - contoursNoise_fyt, 0) + max(contoursNoise_f - contoursNoise_fyb, 0)) * contoursNoise_ssd * 10;
                col += float3(0.5, 0.7, 1)* (max(contoursNoise_f - contoursNoise_fyt, 0) + max(contoursNoise_f - contoursNoise_fyb, 0)) * contoursNoise_ssd * _f1;//f1 边缘线亮度

                col = sqrt(clamp(col, 0, 1));
                return fixed4(col, 1);
                
                //return col;
            }
            ENDCG
        }
    }
}
