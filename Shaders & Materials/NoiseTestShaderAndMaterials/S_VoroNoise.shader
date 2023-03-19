Shader "NoiseCreater/VoroNoise_Test"
{
    Properties
    {
        _A1("A1", Range(3.22, 3.25)) = 3.229//形态变化1取值范围range(-1.239, -1.2);//或者直接叫 形态偏移；
        _B1("B1", float) = 1//亮度值
        _C1("C1", range(-10, 6)) = 6//模糊程度，常配合第一个参数调整
        _D1("D1", Range(0, 20)) = 1.414//形变率；
        _E1("E1", Range(-120, 63)) = 63//假高度，配合增加D1参数；
        //_F1("F1", Range(-61.9, -60)) = -60
        _F1("F1", float) = 43758.5453//随机种子值
        //_G1("G1", float) = 24
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

            float _A1;
            float _B1;
            float _C1;
            float _D1;
            float _E1;
            float _F1;
            //float _G1;

            float3 hash3(float2 coord)
            {
                float3 q = float3(dot(coord, float2(127.1, 311.7)),
                                  dot(coord, float2(269.5, 183.3)),
                                  dot(coord, float2(419.2, 371.9)));
                //return float3(frac(sin(q) * 43758.5453));
                return float3(frac(sin(q) * _F1));
            }
            float voroNoise(float2 coord, float u, float v)
            {
                //float k = 1 + 63 * pow(1 - v, 6.0);
                //float k = _F1 + _E1 * pow(1 - v, _C1);_F1范围在(-61.9, 60)模糊状态到圆圈态，属于测试参数；
                float k = 1 + _E1 * pow(1 - v, _C1);
                float2 i = floor(coord);
                float2 f = frac(coord);

                float2 a = float2(0, 0);
                for (int y = -2; y <= 2; y++)
                {
                    for (int x = -2; x <= 2; x++)
                    {
                        float2 g = float2(y, x);
                        //float3 o = hash3(i + g) * float3(u, u, 1);
                        float3 o = hash3(i + g) * float3(u, u, _B1);//_B1 : 亮度: 默认值为 1；
                        float2 d = g - f + o.xy;
                        //float w = pow(1 - smoothstep(0, 1.414, length(d)), k);
                        float w = pow(1 - smoothstep(0, _D1, length(d)), k);
                        a += float2(o.z * w, w);
                    }
                }
                return a.x/a.y;
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
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                //float2 voroNoise_p = 0.5 * cos(_Time.y * float2(1, 0.5));
                float2 voroNoise_p = 0.5 * _A1;
                voroNoise_p = voroNoise_p * voroNoise_p * (3 - 2 * voroNoise_p);
                voroNoise_p = voroNoise_p * voroNoise_p * (3 - 2 * voroNoise_p);
                voroNoise_p = voroNoise_p * voroNoise_p * (3 - 2 * voroNoise_p);
                float voroNoise_f = voroNoise(uv * 24, voroNoise_p.x, voroNoise_p.y);//24 为UV 尺寸，横向纵向的数量
                float3 VoroNoiseCol = float3(voroNoise_f, voroNoise_f, voroNoise_f);
                return fixed4(VoroNoiseCol, 1);
            }
            ENDCG
        }
    }
}
