Shader "NoiseCreater/Tile5Noise"
{
    Properties
    {
        _a1("a1", Range(0.01, 0.2)) = 0.1//粗细
        _b1("b1", Range(-0.1, 1.1)) = 0.5//单侧偏移值
        _c1("c1", Range(0, 3.15)) = 1.5707963//单侧旋转值
        _d1("d1", Range(0, 3.15)) = 0//双侧旋转值
        _e1("e1", float) = 43758.5453//随机种子数
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

//---------------------------------------------
            float DoubleLiner_rand(float2 p)
            {
                return frac(sin(p* 78.233)* _e1);
            }
            float2x2 DoubleLiner_rot(float a)
            {
	            float ca = cos(a);
                float sa = sin(a);
                return float2x2(ca,-sa,sa,ca);
            }
//---------------------------------------------
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

                float2 guv = uv * 24;//* Noise_Size;
                float2 gid = floor(guv);
                guv = frac(guv) - _b1;//默认0.5
                
                float gidHash = floor((DoubleLiner_rand(gid.x + gid.y * 100)) * 2);
                guv = mul(guv, DoubleLiner_rot(_c1 * (gidHash) + _d1));//1.5707963
                float SF = _ScreenParams.y * _a1/min(_ScreenParams.x, _ScreenParams.y);//默认值_a1:0.1
                float m = 1 - smoothstep(SF, 0, abs(guv.y-guv.x));    
                
                fixed3 col = fixed3(m, m, m);
                
                return fixed4(col, 1);
            }
            ENDCG
        }
    }
}
