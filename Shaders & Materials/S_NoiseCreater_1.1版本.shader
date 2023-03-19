Shader "NoiseCreater/NoiseCreat_1.1"
{
    Properties{}
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

            uniform sampler2D _MainTex;
            float4 _MainTex_ST;
            uniform float _MixPowerSet;
            uniform int _IsUsingTexture;
            uniform int _MathChose;
            uniform int _Invert;

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

            //voroNoise
            uniform float _FormOffsect;
            uniform float _Fuzzy;
            uniform float _Form;
            uniform float _FakeHeight;
            uniform float _RandomSeed;

            //SmokeNoise
            uniform float _SmokeNoise_FormOffsect;
            uniform float _SmokeNoise_Curvature;
            uniform float _SmokeNoise_Level;
            uniform float _SmokeNoise_Particle;
            uniform float _SmokeNoise_MoveLevel;
            uniform float _SmokeNoise_RandomSeed;

            //WorleyNoise
            uniform float _WorleyNoise_FormOffsect;//(-1.5, 1.5)
            uniform float _WorleyNoise_RandomSeed;

            //DowntownNoise
            uniform float _DowntownNoise_Level;
            uniform float _DowntownNoise_LevelBreakSize;
            uniform float _DowntownNoise_LayersMove;
            uniform float _DowntownNoise_RandomSeed;

            //DoubleLinerNoise
            uniform float _DoubleLinerNoise_Thickness;//a1
            uniform float _DoubleLinerNoise_SingleOffset;//b1
            uniform float _DoubleLinerNoise_SingleRot;//c1
            uniform float _DoubleLinerNoise_DoubleRot;//d1
            uniform float _DoubleLinerNoise_RandomSeed;//e1

            //DumbbellNoise
            uniform float _DumbbellNoise_GrayCut;//b1
            uniform float _DumbbellNoise_BrightnessCut;//c1
            uniform float _DumbbellNoise_SideSize_1;//d1
            uniform float _DumbbellNoise_SideSize_2;//e1
            uniform float _DumbbellNoise_GraphicsDislocation_1;//f1
            uniform float _DumbbellNoise_GraphicsDislocation_2;//g1
            uniform float _DumbbellNoise_Direction;//h1
            uniform float _DumbbellNoise_RandomSeed;//a1

            //StepNoise
            uniform float _StepNoise_Step_1;
            uniform float _StepNoise_Step_2;
            uniform float _StepNoise_Step_3;

            //BrickNoise
            uniform float _BrickNoise_CrackOffset;
            uniform float _BrickNoise_X_CrackWidth;
            uniform float _BrickNoise_Y_CrackWidth;

            //WaveletNoise
            uniform float _WaveletNoise_NoiseLayer;//a1
            uniform float _WaveletNoise_SharpPower;//c1
            uniform float _WaveletNoise_FormChange;//f1
            uniform float _WaveletNoise_RandomSeed;//b1
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

            float Step_fbm(float2 coord)
            {
              //Noise大小；
              coord *= _Noise_Size * 0.5;//8默认值
            
              float f = 0.0;
              //五层梯段变化；
              f += 1.0000 * noise(coord); coord = 2.0 * coord;
              f += 0.5000 * noise(coord); coord = 2.0 * coord;
              f += 0.2500 * noise(coord); coord = 2.0 * coord;
              f += 0.1250 * noise(coord); coord = 2.0 * coord;
              f += 0.0625 * noise(coord); coord = 2.0 * coord;
            
              //调整Noise的对比度；
              f /= _Noise_Contrast;
              //f /= lerp(0, 3, _Noise_Contrast);//0.8默认值
            
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

            //VoroNoise
            float3 hash3(float2 coord)
            {
                float3 q = float3(dot(coord, float2(127.1, 311.7)), dot(coord, float2(269.5, 183.3)),dot(coord, float2(419.2, 371.9)));
                //return float3(frac(sin(q) * 43758.5453));
                return float3(frac(sin(q) * lerp(43758.5453, 566458.23412, _RandomSeed)));
            }
            float voroNoise(float2 coord, float u, float v)
            {
                float k = 1 + lerp(-120, 63, _FakeHeight) * pow(1 - v, lerp(-10, 6, _Fuzzy));
                float2 i = floor(coord);
                float2 f = frac(coord);

                float2 a = float2(0, 0);
                for (int y = -2; y <= 2; y++)
                {
                    for (int x = -2; x <= 2; x++)
                    {
                        float2 g = float2(y, x);
                        float3 o = hash3(i + g) * float3(u, u, _NoiseBrightness);
                        float2 d = g - f + o.xy;
                        float w = pow(1 - smoothstep(0, lerp(0, 20, _Form), length(d)), k);
                        a += float2(o.z * w, w);
                    }
                }
                return a.x/a.y;
            }

            //SmokeNoise算法
            float smokeNoise_random(float2 coord)
            {
                return frac(sin(dot(coord, float2(12.9898, 78.233))) * lerp(43758.5453, 66458.23412, _SmokeNoise_RandomSeed));
            }
            float Smoke_Noise(float2 coord)
            {
                float2 i = floor(coord);
                float2 f = frac(coord);

                float a = smokeNoise_random(i);
                float b = smokeNoise_random(i + float2(1, 0));
                float c = smokeNoise_random(i + float2(0, 1));
                float d = smokeNoise_random(i + float2(1, 1));

                float2 u = f * f * (3 - 2 * f);
                return lerp(a, b, u.x) + (c-a) * u.y * (1-u.x) + (d-b) * u.x * u.y;
            }
            float smokeNoise_fbm(float2 coord)
            {
                float v = 0;
                float a = 0.5;
                float shift = float2(lerp(1, 10, _SmokeNoise_FormOffsect), lerp(1, 10, _SmokeNoise_FormOffsect));
                float2x2 rot = float2x2(float2(cos(0.5), sin(0.5)), float2(-sin(0.5), cos(0.5)));
                for (int hh = 0; hh < lerp(1, 10, _SmokeNoise_Level); hh++)
                {
                    v += a * Smoke_Noise(coord);
                    coord = mul(coord, rot) * lerp(1.6, 20, _SmokeNoise_Particle) + shift;
                    a *= 0.5;
                }
                return v;
            }

            //WorleyNoise
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
                return cell_Base + (0.5 + (lerp(-1.5, 1, _WorleyNoise_FormOffsect)) * float2(noise_x, noise_y))/16;
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
                return dist*_NoiseBrightness;
            }

            //DowntownNoise
            float Downtown_rand(float2 p, float timeOffset)
            {
                p += lerp(0.2127, 44.56655, _DowntownNoise_RandomSeed) * timeOffset + p.x + 0.3713 * p.y;
                float2 r = 123.789 * sin(1.823 * p);
                return frac(r.x * r.y);
            }
            float Downtown_sn(float2 p, float timeOffset)
            {
                _DowntownNoise_LayersMove = lerp(0.01, 5, _DowntownNoise_LayersMove);
                float2 i = floor(p - _DowntownNoise_LayersMove);
                float2 f = frac(p - _DowntownNoise_LayersMove);
                f = f*f*f*(f*(f* 6.0 - 15.0)+ 6.0);
                float rt = lerp(Downtown_rand(i, timeOffset), Downtown_rand(i + float2(1.0, 0.0), timeOffset), f.x);
                float rb = lerp(Downtown_rand(i + float2(0.0, 1.0), timeOffset), Downtown_rand(i + float2(1.0, 1.0), timeOffset), f.x);
                return lerp(rt, rb, f.y);
            }

            //DoubleLiner
            float DoubleLiner_rand(float2 p)
            {
                return frac(sin(p* 78.233) * lerp(43758.5453, 43993.5453, _DoubleLinerNoise_RandomSeed));
            }
            float2x2 DoubleLiner_rot(float a)
            {
	            float ca = cos(a);
                float sa = sin(a);
                return float2x2(ca,-sa,sa,ca);
            }

            //DumbbellNoise
            float DumbbellNoise_hash(float2 p)
             {
                 return frac(sin(dot(p,float2(127.1,311.7))) * 43758.5453123);
             }
            float DumbbellNoise_circ(float2 p, float2 c, float r)
             {
                 return abs(r - length(p - c));
             }
            float DumbbellNoise_sharpen(float d, float w)
             {
                 float e = lerp(0.01, 70, _DumbbellNoise_GrayCut) * 10 / min(_ScreenParams.y , _ScreenParams.x);
                 return lerp(0, 2, _DumbbellNoise_BrightnessCut) - smoothstep(-e, e, d - w);
             }
            float DumbbellNoise_pattern(float2 uv)
             {
                 float l1 = DumbbellNoise_sharpen(DumbbellNoise_circ(uv, float2(0, 0), lerp(-0.1, 1.5, _DumbbellNoise_GraphicsDislocation_1)), _DumbbellNoise_SideSize_1);
                 float l2 = DumbbellNoise_sharpen(DumbbellNoise_circ(uv, float2(1, 1), lerp(-0.1, 1.5, _DumbbellNoise_GraphicsDislocation_2)), _DumbbellNoise_SideSize_2);
                 return max(l1,l2);
             }

            //BrickNoise
            float3 BrickNoise_Color(float2 uv)
            {
                float2 coord = floor(uv);
                float2 gv = frac(uv);

                float offset = floor(fmod(uv.y, 2.0)) * lerp(0, 3.13, _BrickNoise_CrackOffset);//1.5 错位位移
                float verticalEdge = abs(cos(uv.x  + offset));//1. 左右宽度

                bool vrtEdge = step(1 - _BrickNoise_X_CrackWidth, verticalEdge) == 1.;
                bool hrtEdge = gv.y > (1 - _BrickNoise_Y_CrackWidth) || gv.y < _BrickNoise_Y_CrackWidth;

                if(hrtEdge || vrtEdge)  
                    return float3(1, 1, 1);
                return float3(0, 0, 0);
            }

            //WaveletNoise
            float WaveletNoise(float2 p, float z, float k) 
            {
                float d=0,s=1,m=0, a;
                for(int i=0; i<lerp(2, 10, _WaveletNoise_NoiseLayer); i++) {
                    float2 q = p*s, g=frac(floor(q)*float2(lerp(123.34, 250.66, _WaveletNoise_RandomSeed),233.53));
                	g += dot(g, g + 23.234);
            		a = frac(g.x * g.y) * 1e3;
                    q = mul((frac(q) - 0.5), float2x2(float2(cos(a), -sin(a)), float2(sin(a), cos(a))));
                    d += sin(q.x * lerp(0, 40, _WaveletNoise_SharpPower) + z) * smoothstep(0.25, 0, dot(q,q))/s * lerp(0, 1.5, _Noise_Contrast);
                    p = mul(p, float2x2(float2(0.54, -0.84), float2(0.84, 0.54))) + i;
                    m += 1./s;
                    s *= k; 
                }
                return d/m;
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
                if(_IsUsingTexture == 0)
                {
                o.uv = v.uv;
                }
                if(_IsUsingTexture == 1)
                {
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                }
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

                //VoroNoise
                float2 voroNoise_p = 0.5 * lerp(3.22, 3.25, _FormOffsect);
                voroNoise_p = voroNoise_p * voroNoise_p * (3 - 2 * voroNoise_p);
                voroNoise_p = voroNoise_p * voroNoise_p * (3 - 2 * voroNoise_p);
                voroNoise_p = voroNoise_p * voroNoise_p * (3 - 2 * voroNoise_p);
                float voroNoise_f = voroNoise(float2((uv.x / X_Size + X_Move), (uv.y / Y_Size + Y_Move)) * _Noise_Size, voroNoise_p.x, voroNoise_p.y);//24 为UV 尺寸，横向纵向的数量
                float3 voroNoiseCol = float3(voroNoise_f, voroNoise_f, voroNoise_f) * 2;

                //SmokeNoise
                float2 smoke_uv = float2((i.uv.x / X_Size + X_Move), (i.uv.y / Y_Size + Y_Move));
                float2 smoke_q = float2(0,0);
                smoke_q.x = smokeNoise_fbm(smoke_uv);
                smoke_q.y = smokeNoise_fbm(smoke_uv + float2(1,1));
                float2 smoke_r = float2(0,0);
                smoke_r.x = smokeNoise_fbm(smoke_uv + lerp(0, 30, _SmokeNoise_Curvature) * smoke_q + float2(1.7, 9.2)+ lerp(0, 5, _SmokeNoise_MoveLevel));
                smoke_r.y = smokeNoise_fbm(smoke_uv + lerp(0, 30, _SmokeNoise_Curvature) * smoke_q + float2(8.3, 2.8)+ 0.126);
                float smoke_f = smokeNoise_fbm(smoke_uv + smoke_r);
                fixed3 smokeNoiseCol = fixed3(smoke_f,smoke_f,smoke_f) * _NoiseBrightness * 2;

                //DowntownNoise
                float2 Downtown_uv = float2((i.uv.x / X_Size + X_Move), (i.uv.y / Y_Size + Y_Move)) * 7 * _Noise_Size / 20;
                float forNumber = _Noise_Contrast;
                float Downtown_Col_Single = 0;
                _DowntownNoise_Level = lerp(0.01, 5, _DowntownNoise_Level);
                _DowntownNoise_LevelBreakSize = lerp(0.01, 20, _DowntownNoise_LevelBreakSize);
                for(int ii = 0; ii < _DowntownNoise_Level; ii++){
                    Downtown_Col_Single += forNumber*Downtown_sn(abs(pow(2, ii)) * Downtown_uv, 1.0);
                    forNumber /= _DowntownNoise_LevelBreakSize;
                }
                fixed3 Downtown_col = fixed3(Downtown_Col_Single, Downtown_Col_Single, Downtown_Col_Single) * _NoiseBrightness * 2;

                //DoubleLinerNoise
                float2 guv = float2((i.uv.x / X_Size + X_Move), (i.uv.y / Y_Size + Y_Move)) * 1.2 * _Noise_Size;//* Noise_Size;
                float2 gid = floor(guv);
                guv = frac(guv) - lerp(-0.1, 1.1, _DoubleLinerNoise_SingleOffset);//默认0.5
                float gidHash = floor((DoubleLiner_rand(gid.x + gid.y * 100)) * 2);
                guv = mul(guv, DoubleLiner_rot(lerp(0, 3.15, _DoubleLinerNoise_SingleRot) * (gidHash) + lerp(0, 3.15, _DoubleLinerNoise_DoubleRot)));//1.5707963
                float SF = _ScreenParams.y * lerp(0.01, 0.2, lerp(0, 3.15, _DoubleLinerNoise_Thickness))/min(_ScreenParams.x, _ScreenParams.y);//默认值_a1:0.1
                float m = 1 - smoothstep(SF, 0, abs(guv.y-guv.x));
                fixed3 DoubleLinerNoise_col = fixed3(m, m, m) * _NoiseBrightness * 2;

                //DumbbellNoise
                float2 DumbbellNoise_uv = (float2((i.uv.x / X_Size + X_Move), (i.uv.y / Y_Size + Y_Move)) * 2 - 1) * _Noise_Size * 0.5;
                float2 DumbbellNoise_st = floor(DumbbellNoise_uv);
                float2 DumbbellNoise_p = frac(DumbbellNoise_uv);
                if (DumbbellNoise_hash(DumbbellNoise_st * lerp(0, 5, _DumbbellNoise_RandomSeed)) > lerp(-0.1, 1, _DumbbellNoise_Direction))
                {
                    DumbbellNoise_p.x = 1 - DumbbellNoise_p.x;
                }
                fixed3 DumbbellNoise_col = fixed3(DumbbellNoise_pattern(DumbbellNoise_p), DumbbellNoise_pattern(DumbbellNoise_p), DumbbellNoise_pattern(DumbbellNoise_p)) * _NoiseBrightness * 2;

                //StepNoise
                float step_Noise = (1 - Step_fbm( float2((uv.x / X_Size + X_Move), (uv.y / Y_Size + Y_Move))));// * _Noise_Size;
                float step_Noise_Single = 0;
                if(step_Noise < _StepNoise_Step_1)
                {
                    step_Noise_Single = 1;
                }
                if(step_Noise >= _StepNoise_Step_1 && step_Noise < _StepNoise_Step_2)
                {
                    step_Noise_Single = 0.66;
                }
                if(step_Noise >= _StepNoise_Step_2 && step_Noise < _StepNoise_Step_3)
                {
                    step_Noise_Single = 0.33;
                }
                _StepNoise_Step_3 = lerp(0, 1.5, _StepNoise_Step_3);
                if(step_Noise >= _StepNoise_Step_3)
                {
                    step_Noise_Single = 0;
                }
                float step_NoiseBrightness = _NoiseBrightness * 2;
                float3 step_Noise_Col = float3(step_Noise_Single, step_Noise_Single, step_Noise_Single) * step_NoiseBrightness;

                //BrickNoise
                float2 BrickNoise_uv = i.uv * _Noise_Size * 1;
                BrickNoise_uv = float2((BrickNoise_uv.x * (1 - _X_Size) + X_Move), (BrickNoise_uv.y * (1 - _Y_Size) + Y_Move));
                fixed3 BrickNoise_Col = BrickNoise_Color(BrickNoise_uv);

                //WaveletNoise
                float2 waveletNoise_UV = float2((i.uv.x / X_Size + X_Move), (i.uv.y / Y_Size + Y_Move));
                fixed3 waveNoise_Col = WaveletNoise(waveletNoise_UV * _Noise_Size * 0.25, lerp(0, 20, _WaveletNoise_FormChange), 1.24) * 0.5 + 0.5;
                if(waveNoise_Col.r > 0.99)
                {
                    waveNoise_Col = fixed3(1, 1, 1);
                }
                if(waveNoise_Col.r < 0.01)
                {
                    waveNoise_Col = fixed3(0, 0, 0);
                }
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
                if(_ChoseNoiseNumber == 4)
                {
                    col = voroNoiseCol;
                }
                if(_ChoseNoiseNumber == 5)
                {
                    col = smokeNoiseCol;
                }
                if(_ChoseNoiseNumber == 6)
                {
                    float2 worleyNoiseUV = float2((i.uv.x / X_Size + X_Move), (i.uv.y / Y_Size + Y_Move)) * _Noise_Size / 20;
                    col = fixed3(Worley(worleyNoiseUV), Worley(worleyNoiseUV), Worley(worleyNoiseUV)) * 2;
                }
                if(_ChoseNoiseNumber == 7)
                {
                    col = Downtown_col;
                }
                if(_ChoseNoiseNumber == 8)
                {
                    col = DoubleLinerNoise_col;
                }
                if(_ChoseNoiseNumber == 9)
                {
                    col = DumbbellNoise_col;
                }
                if(_ChoseNoiseNumber == 10)
                {
                    col = step_Noise_Col;
                }
                if(_ChoseNoiseNumber == 11)
                {
                    col = BrickNoise_Col;
                }
                if(_ChoseNoiseNumber == 12)
                {
                    col = waveNoise_Col * _NoiseBrightness * 2;
                }
//============================================================
                if(_Invert == 1)
                {
                    col = 1 - col;
                }
//============================================================
                if(_IsUsingTexture == 1)
                {
                    if(_MathChose == 0)
                    {
                    float2 texUV = float2(lerp(i.uv.x, (i.uv.x * col.r) * 2, _MixPowerSet), lerp(i.uv.y, (i.uv.y * col.r) * 2, _MixPowerSet));
                    col = tex2D(_MainTex, texUV).rgb;
                    }
                    if(_MathChose == 1)
                    {
                        col = lerp(col, (tex2D(_MainTex, i.uv).rgb + col), _MixPowerSet);
                    }
                    if(_MathChose == 2)
                    {
                        col = lerp(col, (tex2D(_MainTex, i.uv).rgb - col), _MixPowerSet);
                    }
                    if(_MathChose == 3)
                    {
                        col = lerp(col, (tex2D(_MainTex, i.uv).rgb * col), _MixPowerSet);
                    }
                    if(_MathChose == 4)
                    {
                        col = lerp(col, (tex2D(_MainTex, i.uv).rgb / col), _MixPowerSet);
                    }
                }
                ///////////////////////以上/////////////////
                

                return fixed4(col, 1);
            }
            ENDCG
        }
    }
}
