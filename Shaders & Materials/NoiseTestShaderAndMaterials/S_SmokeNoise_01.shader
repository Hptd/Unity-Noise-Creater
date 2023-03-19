Shader "CreaterNoise/NoiseTest_SmokeNoise"{
    Properties{
        _a1("a1", float) = 43758.5453123//RandomSeed
        _b1("b1", Range(1,10)) = 100//烟雾动画形态-横向
        _c1("c1", Range(0,30)) = 0.5//曲率
        _d1("d1", Range(1,10)) = 1//烟雾层次
        _e1("e1", Range(1.6,20)) = 2//烟雾颗粒感
        _f1("f1", float) = 1//明亮度
        _g1("g1", Range(1, 5)) = 0.15//底层层次运动

        _UVPower("UVPower", Range(0,1)) = 0.5
        _MainTexture("TsestTexture",2D) = ""{}
        
    }
    SubShader{
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            //Properties
            float _a1;
            float _b1;
            float _c1;
            int _d1;
            float _e1;
            float _f1;
            float _g1;

            float _UVPower;
            sampler2D _MainTexture;
            float4 _MainTexture_ST;
            
            //Noise算法
            float random(float2 coord)
            {
                //return frac(sin(dot(coord, float2(12.9898, 78.233))) * 43758.5453123);
                return frac(sin(dot(coord, float2(12.9898, 78.233))) * _a1);
            }
            float Smoke_Noise(float2 coord)
            {
                float2 i = floor(coord);
                float2 f = frac(coord);

                float a = random(i);
                float b = random(i + float2(1, 0));
                float c = random(i + float2(0, 1));
                float d = random(i + float2(1, 1));

                float2 u = f * f * (3 - 2 * f);
                return lerp(a, b, u.x) + (c-a) * u.y * (1-u.x) + (d-b) * u.x * u.y;
            }
            float fbm(float2 coord)
            {
                float v = 0;
                float a = 0.5;
                //float shift = float2(100, 100);
                float shift = float2(_b1, _b1);
                float2x2 rot = float2x2(float2(cos(0.5), sin(0.5)), float2(-sin(0.5), cos(0.5)));
                for (int hh = 0; hh < _d1; hh++)
                {
                    v += a * Smoke_Noise(coord);
                    //coord = mul(coord, rot) * 2 + shift;
                    coord = mul(coord, rot) * _e1 + shift;
                    a *= 0.5;
                    //a *= _f1;

                }

                return v;
            }

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
                o.uv = TRANSFORM_TEX(v.uv, _MainTexture);
                //o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //fixed4 col = fixed4(0.5,0.5,1,1);
                
                float2 uv = i.uv;

                //fixed3 col = fixed3(0,0,0);
                float2 q = float2(0,0);
                q.x = fbm(uv);
                q.y = fbm(uv + float2(1,1));

                float2 r = float2(0,0);
                //r.x = fbm(uv + _c1 * q + float2(1.7, 9.2)+ 0.15);//* _Time.y);
                //r.y = fbm(uv + _c1 * q + float2(8.3, 2.8)+ 0.126);//* _Time.y);
                r.x = fbm(uv + _c1 * q + float2(1.7, 9.2)+ _g1);//* _Time.y);
                r.y = fbm(uv + _c1 * q + float2(8.3, 2.8)+ 0.126);//* _Time.y);
                float f = fbm(uv + r);

                fixed3 col = fixed3(f,f,f);// * _f1;

                float2 texUV = float2(lerp(i.uv.x, i.uv.x * f * _f1, _UVPower), lerp(i.uv.y, i.uv.y * f * _f1, _UVPower));

                fixed4 textureCol = tex2D(_MainTexture, texUV);
                //fixed3 textureCol_Mul = tex2D(_MainTexture, i.uv).rgb * col;
                //fixed4 textureCol = tex2D(_MainTexture, i.uv);

                //return fixed4(textureCol_Mul, 1);
                //return fixed4(col, 1);
                return textureCol;
            }
            ENDCG
        }
    }
}
