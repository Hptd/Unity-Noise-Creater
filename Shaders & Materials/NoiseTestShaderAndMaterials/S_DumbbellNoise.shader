Shader "NoiseCreater/DumbbellNoise"
{
    Properties
    {
        _a1("a1", Range(0,5)) = 5//随机种子数
        _b1("b1", Range(0.01, 70)) = 0.1//灰度裁剪
        _c1("c1", Range(0, 2)) = 1//亮度裁切
        _d1("d1", range(0, 1)) = 0.08//侧面尺寸-1
        _e1("e1", range(0, 1)) = 0.08//侧面尺寸-2
        _f1("f1", Range(-0.1, 1.5)) = 0.5//图形错位-1
        _g1("g1", Range(-0.1, 1.5)) = 0.5//图形错位-2
        _h1("h1", Range(-0.1, 1)) = 0.5//顺位方向

        //_MainColor("MainColor", Color) = (1,1,1,1)

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
             float _h1;

             uniform fixed4 _MainColor;
//--------------------------------
             float DumbbellNoise_hash(float2 p)
             {
                 return frac(sin(dot(p,float2(127.1,311.7))) * 43758.5453123);
             }
             float DumbbellNoise_circ(float2 p, float2 c, float r)
             {
                 return abs(r - length(p - c));
             }
             float DumbbellNoise_sharpen(float d, float w)
             {
                 float e = _b1 * 10 / min(_ScreenParams.y , _ScreenParams.x);
                 return _c1 - smoothstep(-e, e, d - w);
             }
             float DumbbellNoise_pattern(float2 uv)
             {
                 float l1 = DumbbellNoise_sharpen(DumbbellNoise_circ(uv, float2(0, 0), _f1), _d1);
                 float l2 = DumbbellNoise_sharpen(DumbbellNoise_circ(uv, float2(1, 1), _g1), _e1);
                 return max(l1,l2);
             }
//--------------------------------
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
                float2 uv = (i.uv * 2 - 1) * 10;

                float2 st = floor(uv);
                float2 p = frac(uv);
                if (DumbbellNoise_hash(st * _a1) > _h1)
                {
                    p.x = 1 - p.x;
                }
                fixed3 col = fixed3(DumbbellNoise_pattern(p), DumbbellNoise_pattern(p), DumbbellNoise_pattern(p));
                col = _MainColor * col;
                
                return fixed4(col, 1);
            }
            ENDCG
        }
    }
}
