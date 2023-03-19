Shader "NoiseCreater/BrickNoise"
{
    Properties
    {
        _a1("a1", float) = 20//³ß´ç
        _b1("b1", Range(0, 3.13)) = 1.5//·ìÏ¶Î»ÒÆ
        _c1("c1", Range(-1,1)) = 0.01//ºáÏò·ìÏ¶¿í¶È
        _d1("d1", Range(0,1)) = 0.1 //×ÝÏò·ìÏ¶¿í¶È
        _e1("e1", float) = 0.5
        _f1("f1", float) = 0.5
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

            float3 BrickNoise_Color(float2 uv)
            {
                float2 coord = floor(uv);
                float2 gv = frac(uv);

                float offset = floor(fmod(uv.y, 2.0))*_b1;//1.5 ´íÎ»Î»ÒÆ
                float verticalEdge = abs(cos(uv.x  + offset));//1. ×óÓÒ¿í¶È
                //float verticalEdge = abs(cos(uv.y  + offset)) * _f1;//1. ×óÓÒ¿í¶È

                bool vrtEdge = step(1 - _c1, verticalEdge) == 1.;
                bool hrtEdge = gv.y > (1 - _d1) || gv.y < _d1;
                
                if(hrtEdge || vrtEdge)  
                    return float3(1, 1, 1);
                return float3(0, 0, 0);
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
                float2 BrickNoise_uv = i.uv * _a1;
                BrickNoise_uv = float2(BrickNoise_uv.x * _e1, BrickNoise_uv.y * _f1);
                fixed3 BrickNoise_Col = BrickNoise_Color(BrickNoise_uv);
                
                return fixed4(BrickNoise_Col, 1);
            }
            ENDCG
        }
    }
}
