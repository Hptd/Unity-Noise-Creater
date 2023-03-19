Shader "NoiseCreater/WorleyNoise"
{
    Properties
    {
        _a1("a1", float) = 16
        _b1("b1", float) = 0.5//亮度
        _c1("c1", Range(-1.5, 1.5)) = 1.5//偏转及其方向；
        _d1("d1", float) = 0.5
        _e1("e1", float) = 0.5
        _f1("f1", float) = 0.5
        _g1("g1", float) = 0.5

        _WorleyNoise_RandomSeed("WorleyNoise", Range(0,1)) = 0.5

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

             float _WorleyNoise_RandomSeed;
//===================================
            float WorleyNoise_random(float2 coord)
            {
                return frac(sin(dot(coord, float2(12.9898, 78.233))) * lerp(43758.5453, 66458.23412, _WorleyNoise_RandomSeed));
            }
            float2 WorleyNoise_get_cell_point(float2 cell)
            {
                float2 cell_Base = cell/16;
                float noise_x = WorleyNoise_random(cell);
                float noise_y = WorleyNoise_random(cell.yx);
                //return cell_Base + (0.5 + 1.5 * float2(noise_x, noise_y))/16;
                return cell_Base + (0.5 + _c1 * float2(noise_x, noise_y))/16;
            }
            float Worley(float2 coord)
            {
                int2 cell = int2(coord * 16);
                float dist = 1;
                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        float2 cell_Point = WorleyNoise_get_cell_point(cell + float2(x-2, y-2));
                        dist = min(dist, distance(cell_Point, coord));
                    } 
                }
                dist /= length(float2(0.0625, 0.0625));
                dist = 1 - dist;
                return dist*_b1;
            }
//===================================
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
                //float2 uv = float2((i.uv.x + _b1)*_d1, (i.uv.y + _e1)*_f1) * _g1;//i.uv;
                float2 uv = i.uv;
                fixed3 col = fixed3(Worley(uv), Worley(uv), Worley(uv));
                
                return fixed4(col, 1);
            }
            ENDCG
        }
    }
}
