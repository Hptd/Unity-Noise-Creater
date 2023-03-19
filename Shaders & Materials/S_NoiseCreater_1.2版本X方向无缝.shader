Shader "NoiseCreater/NoiseCreat_1.2_X_WuFeng"
{
    Properties{
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

            uniform float _CrackWeight;
            uniform float _CrackGrdient;
            uniform sampler2D _X_NoiseResult;
//////////////////////////////////////////////////////////

            //noise�м�ӷ촦���
            fixed3 noise_Mask_Color_Y(float2 uv, float  _CrackGrdient, float _CrackWeight)
            {
            //////////////////////   �޷���ͼ�ӷ�Mask�㷨  //////////////////////////
                fixed3 color_1 = fixed3(0,0,0);
                fixed3 color_2 = fixed3(1,1,1);
                
                //x ����仯
                fixed uvx1 = (1 - _CrackGrdient - uv.x)/(1 - _CrackWeight);
                fixed uvx2 = -(_CrackGrdient - uv.x)/(1 - _CrackWeight);

                fixed3 uvMaskColor1 = smoothstep(color_1, color_2, uvx1);
                fixed3 uvMaskColor2 = smoothstep(color_1, color_2, uvx2);

                //y����仯
                fixed uvx3 = (1 - _CrackGrdient - uv.y)/(1 - _CrackWeight);
                fixed uvx4 = -(_CrackGrdient - uv.y)/(1 - _CrackWeight);

                fixed3 uvMaskColor3 = smoothstep(color_1, color_2, uvx3);
                fixed3 uvMaskColor4 = smoothstep(color_1, color_2, uvx4);

                //x��y����������
                fixed3 mainColor = fixed3(1,1,1);
                
                fixed3 col_X = mainColor * uvMaskColor1.g;
                col_X += mainColor * uvMaskColor2.g;

                fixed3 col_Y = mainColor * uvMaskColor3.g;
                col_Y += mainColor * uvMaskColor4.g;

                //fixed3 maskCol = col_X * col_Y;

                return col_Y;

                //////////////  ����  ///////////////////////////
            }

            fixed3 noise_Mask_Color_X(float2 uv, float  _CrackGrdient, float _CrackWeight)
            {
            //////////////////////   �޷���ͼ�ӷ�Mask�㷨  //////////////////////////
                fixed3 color_1 = fixed3(0,0,0);
                fixed3 color_2 = fixed3(1,1,1);
                
                //x ����仯
                fixed uvx1 = (1 - _CrackGrdient - uv.x)/(1 - _CrackWeight);
                fixed uvx2 = -(_CrackGrdient - uv.x)/(1 - _CrackWeight);

                fixed3 uvMaskColor1 = smoothstep(color_1, color_2, uvx1);
                fixed3 uvMaskColor2 = smoothstep(color_1, color_2, uvx2);

                //y����仯
                fixed uvx3 = (1 - _CrackGrdient - uv.y)/(1 - _CrackWeight);
                fixed uvx4 = -(_CrackGrdient - uv.y)/(1 - _CrackWeight);

                fixed3 uvMaskColor3 = smoothstep(color_1, color_2, uvx3);
                fixed3 uvMaskColor4 = smoothstep(color_1, color_2, uvx4);

                //x��y����������
                fixed3 mainColor = fixed3(1,1,1);
                
                fixed3 col_X = mainColor * uvMaskColor1.g;
                col_X += mainColor * uvMaskColor2.g;

                fixed3 col_Y = mainColor * uvMaskColor3.g;
                col_Y += mainColor * uvMaskColor4.g;

                //fixed3 maskCol = col_X * col_Y;

                return col_X;

                //////////////  ����  ///////////////////////////
            }
            
////////////////////////////////////////////////////////////

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

                //�ӷ� X ���� Mask��
                fixed3 renderTextureInColor1 = fixed3(1,1,1);
                if(uv.x < 0.5)
                {
                    renderTextureInColor1 = tex2D(_X_NoiseResult, float2((uv.x + 0.5), uv.y)).rgb;
                }
                if(uv.x >= 0.5)
                {
                    renderTextureInColor1 = tex2D(_X_NoiseResult, float2((uv.x - 0.5), uv.y)).rgb;
                }

                fixed3 noiseColor00 = tex2D(_X_NoiseResult, uv).rgb;
                fixed3 maskCol_X = noise_Mask_Color_X(uv, _CrackGrdient, _CrackWeight);
                fixed3 finalCol_X = noiseColor00 * (1 - maskCol_X.g) + renderTextureInColor1 * maskCol_X.g;

                return fixed4(finalCol_X, 1);
            }
            ENDCG
        }
    }
}
