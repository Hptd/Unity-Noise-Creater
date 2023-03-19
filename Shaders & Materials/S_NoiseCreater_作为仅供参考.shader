Shader "NoiseCreater/NoiseCreat"
{
    Properties{
        _MaskNumber("_MaskNumber", int) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        //Tags{ "RenderType" = "transparent" }//"Queue" = "Transparent"}

        LOD 100

        Pass
        {
            //Blend One One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            int _MaskNumber;

            uniform int _ChoseNoiseNumber;

            uniform float _Noise_Contrast;
            uniform float _Noise_Size;
            uniform float _NoiseBrightness;

            uniform float _Noise_Fbm_Abs_Sin_Period;
            uniform float _Noise_Fbm_Abs_Sin_BreakSize;

            uniform float _X_Move;
            uniform float _Y_Move;

            uniform float _X_Size;
            uniform float _Y_Size;

            uniform float _CrackWeight;
            uniform float _CrackGrdient;
//////////////////////////////////////////////////////////

            float2 hash22(float2 coord)
            {
              coord = float2(dot(coord, float2(127.1, 311.7)), dot(coord, float2(269.5, 183.3)));
            
              return -1.0 + 2.0 * frac(sin(coord) * 43758.5453123);
            }
            
            float noise(float2 coord)
            {
              float2 pi = floor(coord);
              float2 pf = coord - pi;
            
              //旧版缓和曲线公式算法；
              //float2 w = pf * pf * (3.0 - 2.0 * pf);
              //新版缓和公式算法；
              //float2 w = 6.0 * pow(pf, 5.0) - 15.0 * pow(pf, 4.0) + 10.0 * pow(pf, 3.0);
              float2 w = pf * pf * pf * ( pf * (6.0 * pf - 15.0) + 10.0);
            
              float aa = lerp(dot(hash22(pi + float2(0.0, 0.0)), pf - float2(0.0, 0.0)),
                             dot(hash22(pi + float2(1.0, 0.0)), pf - float2(1.0, 0.0)), w.x);
            
              float bb = lerp(dot(hash22(pi + float2(0.0, 1.0)), pf - float2(0.0, 1.0)),
                             dot(hash22(pi + float2(1.0, 1.0)), pf - float2(1.0, 1.0)), w.x);
            
              float result = lerp(aa, bb, w.y);
              return result;
            }
            
            float fbm(float2 coord)
            {
              //Noise大小；
              coord *= _Noise_Size;//8默认值
            
              float f = 0.0;
              //五层梯段变化；
              f += 1.0000 * noise(coord); coord = 2.0 * coord;
              f += 0.5000 * noise(coord); coord = 2.0 * coord;
              f += 0.2500 * noise(coord); coord = 2.0 * coord;
              f += 0.1250 * noise(coord); coord = 2.0 * coord;
              f += 0.0625 * noise(coord); coord = 2.0 * coord;
            
              //调整Noise的对比度；
              //f /= 1.9375;
              f /= lerp(0, 3, _Noise_Contrast);//0.8默认值
            
              return f;
            }
            
            float fbm_abs(float2 coord)
            {
              //Noise大小；
              coord *= _Noise_Size;
            
              float f = 0.0;
              //五层梯段变化；
              f += 1.0000 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.5000 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.2500 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.1250 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.0625 * abs(noise(coord)); coord = 2.0 * coord;
            
              //调整Noise的对比度；
              //f /= 1.9375;
              f /= lerp(0, 10, _Noise_Contrast);
            
              return f;
            }
            
            float fbm_abs_sin(float2 coord)
            {
              //Noise大小；
              coord *= _Noise_Size;
            
              float f = 0.0;
              //五层梯段变化；
              f += 1.0000 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.5000 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.2500 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.1250 * abs(noise(coord)); coord = 2.0 * coord;
              f += 0.0625 * abs(noise(coord)); coord = 2.0 * coord;
            
              //调整Noise的破碎程度;
              f /= lerp(0.001, 2, _Noise_Fbm_Abs_Sin_BreakSize);
              f = sin(f + coord.x/lerp(0.001, 200,_Noise_Fbm_Abs_Sin_Period));//20 为周期，且当 f /= >0.1;能看出明显周期时起作用；
            
              return f;
            }
            
            float noise_itself(float2 coord)
            {
              return noise(coord * _Noise_Size);//噪波尺寸12;
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

                //Noise算法
                ////////////////////PerlinNoise///////////////////
                
                float X_Move = lerp(-2, 2, _X_Move);
                float Y_Move = lerp(-2, 2, _Y_Move);

                float X_Size = lerp(1, 200, _X_Size);
                float Y_Size = lerp(1, 200, _Y_Size);

                float noise_Self = noise_itself( float2((uv.x / X_Size + X_Move), (uv.y / Y_Size + Y_Move)));
                float noiseSelfContrast = lerp(-1, 1.7, _Noise_Contrast);
                float noiseSelfBrightness = lerp(0, 6, _NoiseBrightness);
                float3 noisePerlin = float3( noiseSelfContrast - noise_Self, noiseSelfContrast - noise_Self, noiseSelfContrast - noise_Self ) * noiseSelfBrightness;//_NoiseSelf_Contrast为对比度；

                float noise_Cloud = 1 - fbm( float2((uv.x / X_Size + X_Move), (uv.y / Y_Size + Y_Move)));
                float fbmNoiseBrightness = lerp(-2, 2, _NoiseBrightness);
                float3 noiseCloud = float3(noise_Cloud * fbmNoiseBrightness, noise_Cloud * fbmNoiseBrightness, noise_Cloud * fbmNoiseBrightness);

                float noise_Cloud_Abs = fbm_abs( float2((uv.x  / X_Size + X_Move), (uv.y  / Y_Size + Y_Move)));
                float fbm_Abs_noiseBrightness = lerp(0, 16, _NoiseBrightness);
                float3 noiseCloudAbs = float3(noise_Cloud_Abs * fbm_Abs_noiseBrightness, noise_Cloud_Abs * fbm_Abs_noiseBrightness, noise_Cloud_Abs * fbm_Abs_noiseBrightness);

                float noise_Cloud_Abs_Sin = fbm_abs_sin( float2((uv.x / X_Size + X_Move), (uv.y / Y_Size + Y_Move)));
                float fbm_Abs_Sin_Brightness = lerp(0, 16, _NoiseBrightness);
                float3 noiseCloudAbsSin = float3(noise_Cloud_Abs_Sin, noise_Cloud_Abs_Sin, noise_Cloud_Abs_Sin) * fbm_Abs_Sin_Brightness;
                /////////////////  Noise 算法  //////////////////////

                ////////// Noise 效果输出 //////////////////
                fixed3 col = fixed3(1, 1, 1);

                if(_ChoseNoiseNumber == 0)
                {
                    col = noisePerlin;
                }
                if(_ChoseNoiseNumber == 1)
                {
                    col = noiseCloud;
                }
                if(_ChoseNoiseNumber == 2)
                {
                    col = noiseCloudAbs;
                }
                if(_ChoseNoiseNumber == 3)
                {
                    col = noiseCloudAbsSin;
                }
                ///////////////////////以上/////////////////

                //////////////  无缝贴图算法 —— 切分四块 变换顺序叠加输出  ////////////////////
                fixed3 uvMaskColor = fixed3(0,0,0);

                if(_MaskNumber == 1 && uv.x > 0.5 && uv.y < 0.5)
                {
                    uvMaskColor = fixed3(1,1,1);
                }
                if(_MaskNumber == 2 && uv.x < 0.5 && uv.y < 0.5)
                {
                    uvMaskColor = fixed3(1,1,1);
                }
                if(_MaskNumber == 3 && uv.x > 0.5 && uv.y > 0.5)
                {
                    uvMaskColor = fixed3(1,1,1);
                }
                if(_MaskNumber == 4 && uv.x < 0.5 && uv.y > 0.5)
                {
                    uvMaskColor = fixed3(1,1,1);
                }
                
                fixed3 finalColor = col * uvMaskColor.g;
                //////////////  以上  ////////////////////////////////////

                /////////////  无缝贴图算法 —— 处理接缝平滑  /////////////////////////////////
                if(_MaskNumber == 5)//适用在 RenderGround_接缝处理层；
                {
                    //////////////////////   无缝贴图接缝Mask算法  //////////////////////////
                    fixed3 color_1 = fixed3(0,0,0);
                    fixed3 color_2 = fixed3(1,1,1);
                    
                    //x 方向变化
                    fixed uvx1 = (1 - _CrackGrdient - uv.x)/(1 - _CrackWeight);
                    fixed uvx2 = -(_CrackGrdient - uv.x)/(1 - _CrackWeight);

                    fixed3 uvMaskColor1 = smoothstep(color_1, color_2, uvx1);
                    fixed3 uvMaskColor2 = smoothstep(color_1, color_2, uvx2);
                    //////////////////////////////////

                    //y方向变化
                    fixed uvx3 = (1 - _CrackGrdient - uv.y)/(1 - _CrackWeight);
                    fixed uvx4 = -(_CrackGrdient - uv.y)/(1 - _CrackWeight);

                    fixed3 uvMaskColor3 = smoothstep(color_1, color_2, uvx3);
                    fixed3 uvMaskColor4 = smoothstep(color_1, color_2, uvx4);
                    ////////////////////////////////////

                    ////////  x、y方向进行组合  /////////////////////
                    fixed3 mainColor = fixed3(1,1,1);
                    
                    fixed3 col_X = mainColor * uvMaskColor1.g;
                    col_X += mainColor * uvMaskColor2.g;

                    fixed3 col_Y = mainColor * uvMaskColor3.g;
                    col_Y += mainColor * uvMaskColor4.g;

                    fixed3 maskCol = col_X * col_Y;

                    finalColor = col * (1 - maskCol);
                    //////////////  以上  ///////////////////////////
                }
                //////////////////  以上   ///////////////////////////

                
                if(finalColor.g == 0)
                {
                    discard;
                }
                ///////  最终输出效果  /////////////


                return fixed4(finalColor, 1);
            }
            ENDCG
        }
    }
}
