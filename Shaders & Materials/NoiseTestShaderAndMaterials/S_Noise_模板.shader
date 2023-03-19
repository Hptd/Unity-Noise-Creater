Shader "Unlit/S_Noise"
{
    Properties
    {
        _a1("a1", float) = 0.5
        _b1("b1", float) = 0.5
        _c1("c1", float) = 0.5
        _d1("d1", float) = 0.5
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
                fixed4 col = fixed4(1,0.5,1,1);
                
                return col;
            }
            ENDCG
        }
    }
}
