Shader "NoiseCreater/NoiseCreat_1.2_Y_WuFeng"
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

            uniform sampler2D _Y_NoiseResult;

//////////////////////////////////////////////////////////

            //noise中间接缝处理层
            fixed3 noise_Mask_Color_Y(float2 uv, float  _CrackGrdient, float _CrackWeight)
            {
            //////////////////////   无缝贴图接缝Mask算法  //////////////////////////
                fixed3 color_1 = fixed3(0,0,0);
                fixed3 color_2 = fixed3(1,1,1);
                
                //x 方向变化
                fixed uvx1 = (1 - _CrackGrdient - uv.x)/(1 - _CrackWeight);
                fixed uvx2 = -(_CrackGrdient - uv.x)/(1 - _CrackWeight);

                fixed3 uvMaskColor1 = smoothstep(color_1, color_2, uvx1);
                fixed3 uvMaskColor2 = smoothstep(color_1, color_2, uvx2);

                //y方向变化
                fixed uvx3 = (1 - _CrackGrdient - uv.y)/(1 - _CrackWeight);
                fixed uvx4 = -(_CrackGrdient - uv.y)/(1 - _CrackWeight);

                fixed3 uvMaskColor3 = smoothstep(color_1, color_2, uvx3);
                fixed3 uvMaskColor4 = smoothstep(color_1, color_2, uvx4);

                //x、y方向进行组合
                fixed3 mainColor = fixed3(1,1,1);
                
                fixed3 col_X = mainColor * uvMaskColor1.g;
                col_X += mainColor * uvMaskColor2.g;

                fixed3 col_Y = mainColor * uvMaskColor3.g;
                col_Y += mainColor * uvMaskColor4.g;

                //fixed3 maskCol = col_X * col_Y;

                return col_Y;

                //////////////  以上  ///////////////////////////
            }

            fixed3 noise_Mask_Color_X(float2 uv, float  _CrackGrdient, float _CrackWeight)
            {
            //////////////////////   无缝贴图接缝Mask算法  //////////////////////////
                fixed3 color_1 = fixed3(0,0,0);
                fixed3 color_2 = fixed3(1,1,1);
                
                //x 方向变化
                fixed uvx1 = (1 - _CrackGrdient - uv.x)/(1 - _CrackWeight);
                fixed uvx2 = -(_CrackGrdient - uv.x)/(1 - _CrackWeight);

                fixed3 uvMaskColor1 = smoothstep(color_1, color_2, uvx1);
                fixed3 uvMaskColor2 = smoothstep(color_1, color_2, uvx2);

                //y方向变化
                fixed uvx3 = (1 - _CrackGrdient - uv.y)/(1 - _CrackWeight);
                fixed uvx4 = -(_CrackGrdient - uv.y)/(1 - _CrackWeight);

                fixed3 uvMaskColor3 = smoothstep(color_1, color_2, uvx3);
                fixed3 uvMaskColor4 = smoothstep(color_1, color_2, uvx4);

                //x、y方向进行组合
                fixed3 mainColor = fixed3(1,1,1);
                
                fixed3 col_X = mainColor * uvMaskColor1.g;
                col_X += mainColor * uvMaskColor2.g;

                fixed3 col_Y = mainColor * uvMaskColor3.g;
                col_Y += mainColor * uvMaskColor4.g;

                //fixed3 maskCol = col_X * col_Y;

                return col_X;

                //////////////  以上  ///////////////////////////
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

                fixed3 noiseColor000 = tex2D(_Y_NoiseResult, uv).rgb;
                fixed3 noiseColor00 = fixed3(1,1,1);

                if(uv.y < 0.5)
                {
                    noiseColor00 = tex2D(_Y_NoiseResult, float2(uv.x, uv.y + 0.5)).rgb;
                    
                }
                if(uv.y >= 0.5)
                {
                    noiseColor00 = tex2D(_Y_NoiseResult, float2(uv.x, uv.y - 0.5)).rgb;
                }

                //接缝 Y 方向 Mask层

                fixed3 maskCol_Y = noise_Mask_Color_Y(uv, _CrackGrdient, _CrackWeight);
                fixed3 finalCol_Y = noiseColor00 * maskCol_Y.g + noiseColor000 * (1 - maskCol_Y.g);

                return fixed4(finalCol_Y, 1);
            }
            ENDCG
        }
    }
}
