Shader "NoiseCreater/ColorfullNoise_1"
{
    Properties
    {
        _a1("a1", Range(0, 10)) = 5//循环次数，收敛性
        _b1("b1", Range(-2, 1)) = 0.5//泛光强度
        _c1("c1", Range(-0.1, 0.8)) = -0.1//曝光值
        _d1("d1", Range(-1, 1)) = 1//正负片
        _e1("e1", Range(0, 5)) = 1//中心大小
        _f1("f1", Range(0, 10)) = 2.5//泛光范围
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

             uniform fixed4 _MainColor_1;
             uniform fixed4 _MainColor_2;
             uniform float _TimeRun;

//=====================================
            float2x2 Ether_m(float a)
            {
                float c=cos(a);
                float s=sin(a);
                return float2x2(c,-s,s,c);
            }
            float Ether_map(float3 p)
            {
                p.xz = mul(p.xz, Ether_m(_TimeRun * 0.4));
                p.xy = mul(p.xy, Ether_m(_TimeRun * 0.3));
                float3 q = p*2 + _TimeRun;
                float r1 = length(p + float3(sin(_TimeRun * 0.7), sin(_TimeRun * 0.7), sin(_TimeRun * 0.7)));
                float r2 = log(length(p) + _e1);
                float r3 = sin(q.x + sin(q.z + sin(q.y))) * 0.5 - 1;
                return  r1 * r2 + r3;
            }
//=====================================
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
                float2 uv = (i.uv * 2 - 1) * 0.7;
                fixed3 cl = fixed3(0,0,0);
                float d = 2.5;

                for(int ii=0; ii<=_a1; ii++)	
                {
	            	float3 p = float3(0, 0, 5) + normalize(float3(uv.x, uv.y, -1)) * d;
                    float rz = Ether_map(p);
	            	float f =  clamp((rz - Ether_map(p + 0.1)) * _b1, _c1, _d1);//b1 = 0.5; c1 = -0.1; d1 = 1;
                    //float3 l = float3(0.1, 0.3, 0.4) + float3(5, 2.5, 3) * f;
                    float3 l = _MainColor_1 + _MainColor_2 * 4.5 * f;
                    cl = cl * l + smoothstep(_f1, 0, rz)*.7 * l;
	            	d += min(rz, 1);
	            }
                return fixed4(cl, 1);// * _MainColor;
            }
            ENDCG
        }
    }
}
