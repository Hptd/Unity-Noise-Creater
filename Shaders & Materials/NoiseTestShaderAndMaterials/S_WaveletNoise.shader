Shader "Unlit/S_Noise"
{
    Properties
    {
        _a1("a1", Range(2,10)) = 4//噪波层次
        _b1("b1", float) = 123.34//随机种子数
        _c1("c1", Range(0, 20)) = 10//噪波清晰度
        _d1("d1", Range(0,1.5)) = 1//对比度
        _e1("e1", float) = 0.5//亮度
        _f1("f1", Range(1, 10)) = 0//形态变化
        _g1("g1", float) = 0.5

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

//=============================

            float WaveletNoise(float2 p, float z, float k) 
            {
                float d=0,s=1,m=0, a;
                for(int i=0; i<_a1; i++) {
                    float2 q = p*s, g=frac(floor(q)*float2(_b1,233.53));
                	g += dot(g, g + 23.234);
            		a = frac(g.x * g.y) * 1e3;
                    q = mul((frac(q) - 0.5), float2x2(float2(cos(a), -sin(a)), float2(sin(a), cos(a))));
                    d += sin(q.x * _c1 + z) * smoothstep(0.25, 0, dot(q,q))/s * _d1;
                    p = mul(p, float2x2(float2(0.54, -0.84), float2(0.84, 0.54))) + i;
                    m += 1./s;
                    s *= k; 
                }
                return d/m;
            }

//=============================

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
                float2 waveletNoise_UV = i.uv;
                fixed3 waveNoise_Col = WaveletNoise(waveletNoise_UV * 5, _f1, 1.24) * 0.5 + 0.5;
                
                if(waveNoise_Col.r > 0.99)
                {
                    waveNoise_Col = fixed3(1, 0, 0);
                }
                if(waveNoise_Col.r < 0.01)
                {
                    waveNoise_Col = fixed3(0, 0, 1);
                }

                return fixed4(waveNoise_Col, 1) * _e1;
            }
            ENDCG
        }
    }
}
