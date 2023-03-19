using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class SetCount : MonoBehaviour
    {
        public Dropdown noiseChose;

        public InputField inputField_Noise_Size;
        public Slider slider_noise_Contrast;
        public InputField inputfield_noise_Contrast;
        
        public Slider slider_CloudNoiseBrightness;
        public InputField inputfield_CloudNoiseBrightness;

        public Material material;

        public Slider slider_Noise_Period;
        public InputField inputfield_Noise_Period;
        public Slider slider_Noise_BreakSize;
        public InputField inputfield_Noise_BreakSize;

        //Noise Move
        public Slider x_Move;
        public InputField inputfield_x_Move;
        public Slider y_Move;
        public InputField inputfield_y_Move;

        //Noise Size
        public Slider x_Size;
        public InputField inputfield_x_Size;
        public Slider y_Size;
        public InputField inputfield_y_Size;

        //VoroNoise特性参数
        public Slider slider_VoroNoise_FormOffsect;
        public InputField inputfield_VoroNoise_FormOffsect;
        public Slider slider_VoroNoise_Fuzzy;
        public InputField inputfield_VoroNoise_Fuzzy;
        public Slider slider_VoroNoise_Form;
        public InputField inputfield_VoroNoise_Form;
        public Slider slider_VoroNoise_FakHeight;
        public InputField inputfield_VoroNoise_FakHeight;
        public Slider slider_VoroNoise_RandomSeed;
        public InputField inputfield_VoroNoise_RandomSeed;

        private int choseNoiseName = 0;

        //Canvas 选择并设置状态
        public Canvas canvas_Common;
        public Canvas canvas_PeriodNoise;
        public Canvas canvas_VoroNoise;
        public Canvas canvas_SmokeNoise;
        public Canvas canvas_WorleyNoise;
        public Canvas canvas_DowntownNoise;
        public Canvas canvas_DoubleLinerNoise;
        public Canvas canvas_DumbbellNoise;
        public Canvas canvas_StepNoise;
        public Canvas canvas_BrickNoise;
        public Canvas canvas_WaveletNoise;

        private void Start()
        {
            //input.text = slider.value.ToString();    //初始化
            Initialize(inputfield_noise_Contrast, slider_noise_Contrast);
            Initialize(inputfield_CloudNoiseBrightness, slider_CloudNoiseBrightness);
            Initialize(inputfield_Noise_Period, slider_Noise_Period);
            Initialize(inputfield_Noise_BreakSize, slider_Noise_BreakSize);
            Initialize(inputfield_x_Move, x_Move);
            Initialize(inputfield_y_Move, y_Move);
            Initialize(inputfield_x_Size, x_Size);
            Initialize(inputfield_y_Size, y_Size);

            //voroNoise特效参数双模调整
            Initialize(inputfield_VoroNoise_FormOffsect, slider_VoroNoise_FormOffsect);
            Initialize(inputfield_VoroNoise_Fuzzy, slider_VoroNoise_Fuzzy);
            Initialize(inputfield_VoroNoise_Form, slider_VoroNoise_Form);
            Initialize(inputfield_VoroNoise_FakHeight, slider_VoroNoise_FakHeight);
            Initialize(inputfield_VoroNoise_RandomSeed, slider_VoroNoise_RandomSeed);

            slider_noise_Contrast.onValueChanged.AddListener(this.SliderChange_Contrast);
            inputfield_noise_Contrast.onValueChanged.AddListener(this.InputChange_Contrast);
            slider_CloudNoiseBrightness.onValueChanged.AddListener(this.SliderChange_CloudNoiseBrightness);
            inputfield_CloudNoiseBrightness.onValueChanged.AddListener(this.InputChange_CloudNoiseBrightness);
            slider_Noise_Period.onValueChanged.AddListener(this.SliderChange_Noise_Period);
            inputfield_Noise_Period.onValueChanged.AddListener(this.InputChange_Noise_Period);
            slider_Noise_BreakSize.onValueChanged.AddListener(this.SliderChange_Noise_BreakSize);
            inputfield_Noise_BreakSize.onValueChanged.AddListener(this.InputChange_Noise_BreakSize);
            x_Move.onValueChanged.AddListener(this.SliderChange_x_Move);
            inputfield_x_Move.onValueChanged.AddListener(this.InputChange_x_Move);
            y_Move.onValueChanged.AddListener(this.SliderChange_y_Move);
            inputfield_y_Move.onValueChanged.AddListener(this.InputChange_y_Move);
            x_Size.onValueChanged.AddListener(this.SliderChange_x_Size);
            inputfield_x_Size.onValueChanged.AddListener(this.InputChange_x_Size);
            y_Size.onValueChanged.AddListener(this.SliderChange_y_Size);
            inputfield_y_Size.onValueChanged.AddListener(this.InputChange_y_Size);

            //VoroNoise 特性参数初始化
            slider_VoroNoise_FormOffsect.onValueChanged.AddListener(this.SliderChange_VoroNoise_FormOffsect);
            inputfield_VoroNoise_FormOffsect.onValueChanged.AddListener(this.InputChange_VoroNoise_FormOffsect);
            slider_VoroNoise_Fuzzy.onValueChanged.AddListener(this.SliderChange_VoroNoise_Fuzzy);
            inputfield_VoroNoise_Fuzzy.onValueChanged.AddListener(this.InputChange_VoroNoise_Fuzzy);
            slider_VoroNoise_Form.onValueChanged.AddListener(this.SliderChange_VoroNoise_Form);
            inputfield_VoroNoise_Form.onValueChanged.AddListener(this.InputChange_VoroNoise_Form);
            slider_VoroNoise_FakHeight.onValueChanged.AddListener(this.SliderChange_VoroNoise_FakHeight);
            inputfield_VoroNoise_FakHeight.onValueChanged.AddListener(this.InputChange_VoroNoise_FakHeight);
            slider_VoroNoise_RandomSeed.onValueChanged.AddListener(this.SliderChange_VoroNoise_RandomSeed);
            inputfield_VoroNoise_RandomSeed.onValueChanged.AddListener(this.InputChange_VoroNoise_RandomSeed);

        }

        //初始化参数
        void Initialize(InputField inputField, Slider slider)
        { 
            inputField.text = slider.value.ToString();
        }
        //Slider 2 InoutField
        void SliderChange_Contrast(float value)
        {
            inputfield_noise_Contrast.text = slider_noise_Contrast.value.ToString();
        }
        void SliderChange_CloudNoiseBrightness(float value)
        {
            inputfield_CloudNoiseBrightness.text = slider_CloudNoiseBrightness.value.ToString();
        }
        void SliderChange_Noise_Period(float value)
        {
            inputfield_Noise_Period.text = slider_Noise_Period.value.ToString();
        }
        void SliderChange_Noise_BreakSize(float value)
       {
            inputfield_Noise_BreakSize.text = slider_Noise_BreakSize.value.ToString();
       }
        void SliderChange_x_Move(float value)
        {
            inputfield_x_Move.text = x_Move.value.ToString();
        }
        void SliderChange_y_Move(float value)
        {
            inputfield_y_Move.text = y_Move.value.ToString();
        }
        void SliderChange_x_Size(float value)
        {
            inputfield_x_Size.text = x_Size.value.ToString();
        }
        void SliderChange_y_Size(float value)
        {
            inputfield_y_Size.text = y_Size.value.ToString();
        }

        //VoroNoise特性参数
        void SliderChange_VoroNoise_FormOffsect(float value)
        {
            inputfield_VoroNoise_FormOffsect.text = slider_VoroNoise_FormOffsect.value.ToString();
        }
        void SliderChange_VoroNoise_Fuzzy(float value)
        {
            inputfield_VoroNoise_Fuzzy.text = slider_VoroNoise_Fuzzy.value.ToString();
        }
        void SliderChange_VoroNoise_Form(float value)
        {
            inputfield_VoroNoise_Form.text = slider_VoroNoise_Form.value.ToString();
        }
        void SliderChange_VoroNoise_FakHeight(float value)
        {
            inputfield_VoroNoise_FakHeight.text = slider_VoroNoise_FakHeight.value.ToString();
        }
        void SliderChange_VoroNoise_RandomSeed(float value)
        {
            inputfield_VoroNoise_RandomSeed.text = slider_VoroNoise_RandomSeed.value.ToString();
        }

        //InoutField 2 Slider
        void InputChange_Contrast(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_noise_Contrast.maxValue)
            {
                slider_noise_Contrast.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_noise_Contrast.maxValue)
            {
                slider_noise_Contrast.maxValue = float.Parse(va);
                slider_noise_Contrast.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_noise_Contrast.minValue)
            {
                slider_noise_Contrast.minValue = float.Parse(va);
                slider_noise_Contrast.value = float.Parse(va);
            }
        }
        void InputChange_CloudNoiseBrightness(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_CloudNoiseBrightness.maxValue)
            {
                slider_CloudNoiseBrightness.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_CloudNoiseBrightness.maxValue)
            {
                slider_CloudNoiseBrightness.maxValue = float.Parse(va);
                slider_CloudNoiseBrightness.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_CloudNoiseBrightness.minValue)
            {
                slider_CloudNoiseBrightness.minValue = float.Parse(va);
                slider_CloudNoiseBrightness.value = float.Parse(va);
            }
        }
        void InputChange_Noise_Period(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_Noise_Period.maxValue)
            {
                slider_Noise_Period.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_Noise_Period.maxValue)
            {
                slider_Noise_Period.maxValue = float.Parse(va);
                slider_Noise_Period.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_Noise_Period.minValue)
            {
                slider_Noise_Period.minValue = float.Parse(va);
                slider_Noise_Period.value = float.Parse(va);
            }
        }
        void InputChange_Noise_BreakSize(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_Noise_BreakSize.maxValue)
            {
                slider_Noise_BreakSize.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_noise_Contrast.maxValue)
            {
                slider_Noise_BreakSize.maxValue = float.Parse(va);
                slider_Noise_BreakSize.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_Noise_BreakSize.minValue)
            {
                slider_Noise_BreakSize.minValue = float.Parse(va);
                slider_Noise_BreakSize.value = float.Parse(va);
            }
        }
        void InputChange_x_Move(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= x_Move.maxValue)
            {
                x_Move.value = float.Parse(va);
            }
            if (float.Parse(va) > x_Move.maxValue)
            {
                x_Move.maxValue = float.Parse(va);
                x_Move.value = float.Parse(va);
            }
            if (float.Parse(va) < x_Move.minValue)
            {
                x_Move.minValue = float.Parse(va);
                x_Move.value = float.Parse(va);
            }
        }
        void InputChange_y_Move(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= y_Move.maxValue)
            {
                y_Move.value = float.Parse(va);
            }
            if (float.Parse(va) > y_Move.maxValue)
            {
                y_Move.maxValue = float.Parse(va);
                y_Move.value = float.Parse(va);
            }
            if (float.Parse(va) < y_Move.minValue)
            {
                y_Move.minValue = float.Parse(va);
                y_Move.value = float.Parse(va);
            }
        }
        void InputChange_x_Size(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= x_Size.maxValue)
            {
                x_Size.value = float.Parse(va);
            }
            if (float.Parse(va) > x_Size.maxValue)
            {
                x_Size.maxValue = float.Parse(va);
                x_Size.value = float.Parse(va);
            }
            if (float.Parse(va) < x_Size.minValue)
            {
                x_Size.minValue = float.Parse(va);
                x_Size.value = float.Parse(va);
            }
        }
        void InputChange_y_Size(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= y_Size.maxValue)
            {
                y_Size.value = float.Parse(va);
            }
            if (float.Parse(va) > y_Size.maxValue)
            {
                y_Size.maxValue = float.Parse(va);
                y_Size.value = float.Parse(va);
            }
            if (float.Parse(va) < y_Size.minValue)
            {
                y_Size.minValue = float.Parse(va);
                y_Size.value = float.Parse(va);
            }
        }

        //VoroNoise特性参数
        void InputChange_VoroNoise_FormOffsect(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_VoroNoise_FormOffsect.maxValue)
            {
                slider_VoroNoise_FormOffsect.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_VoroNoise_FormOffsect.maxValue)
            {
                slider_VoroNoise_FormOffsect.maxValue = float.Parse(va);
                slider_VoroNoise_FormOffsect.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_VoroNoise_FormOffsect.minValue)
            {
                slider_VoroNoise_FormOffsect.minValue = float.Parse(va);
                slider_VoroNoise_FormOffsect.value = float.Parse(va);
            }
        }
        void InputChange_VoroNoise_Fuzzy(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_VoroNoise_Fuzzy.maxValue)
            {
                slider_VoroNoise_Fuzzy.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_VoroNoise_Fuzzy.maxValue)
            {
                slider_VoroNoise_Fuzzy.maxValue = float.Parse(va);
                slider_VoroNoise_Fuzzy.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_VoroNoise_Fuzzy.minValue)
            {
                slider_VoroNoise_Fuzzy.minValue = float.Parse(va);
                slider_VoroNoise_Fuzzy.value = float.Parse(va);
            }
        }
        void InputChange_VoroNoise_Form(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_VoroNoise_Form.maxValue)
            {
                slider_VoroNoise_Form.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_VoroNoise_Form.maxValue)
            {
                slider_VoroNoise_Form.maxValue = float.Parse(va);
                slider_VoroNoise_Form.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_VoroNoise_Form.minValue)
            {
                slider_VoroNoise_Form.minValue = float.Parse(va);
                slider_VoroNoise_Form.value = float.Parse(va);
            }
        }
        void InputChange_VoroNoise_FakHeight(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_VoroNoise_FakHeight.maxValue)
            {
                slider_VoroNoise_FakHeight.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_VoroNoise_FakHeight.maxValue)
            {
                slider_VoroNoise_FakHeight.maxValue = float.Parse(va);
                slider_VoroNoise_FakHeight.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_VoroNoise_FakHeight.minValue)
            {
                slider_VoroNoise_FakHeight.minValue = float.Parse(va);
                slider_VoroNoise_FakHeight.value = float.Parse(va);
            }
        }
        void InputChange_VoroNoise_RandomSeed(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_VoroNoise_RandomSeed.maxValue)
            {
                slider_VoroNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_VoroNoise_RandomSeed.maxValue)
            {
                slider_VoroNoise_RandomSeed.maxValue = float.Parse(va);
                slider_VoroNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_VoroNoise_RandomSeed.minValue)
            {
                slider_VoroNoise_RandomSeed.minValue = float.Parse(va);
                slider_VoroNoise_RandomSeed.value = float.Parse(va);
            }
        }

        void Update()
        {
            choseNoiseName = noiseChose.GetComponent<Dropdown>().value;

            material.SetInt("_ChoseNoiseNumber", choseNoiseName);
        }

        private void FixedUpdate()
        {
            if (choseNoiseName == 0 || choseNoiseName == 1 || choseNoiseName == 2)
            {
                canvas_Common.enabled = true;
                canvas_PeriodNoise.enabled = false;
                canvas_VoroNoise.enabled = false;
                canvas_SmokeNoise.enabled = false;
                canvas_WorleyNoise.enabled = false;
                canvas_DowntownNoise.enabled = false;
                canvas_DoubleLinerNoise.enabled = false;
                canvas_DumbbellNoise.enabled = false;
                canvas_StepNoise.enabled = false;
                canvas_BrickNoise.enabled = false;
                canvas_WaveletNoise.enabled = false;
                

                float noiseSelfBrightness = slider_CloudNoiseBrightness.value;
                material.SetFloat("_NoiseBrightness", noiseSelfBrightness);

                float noiseSelfContrast = slider_noise_Contrast.value;
                material.SetFloat("_Noise_Contrast", noiseSelfContrast);

                float noiseSelfSize = float.Parse(inputField_Noise_Size.text);
                material.SetFloat("_Noise_Size", noiseSelfSize);

                float xMove = x_Move.value;
                float yMove = y_Move.value;
                material.SetFloat("_X_Move", xMove);
                material.SetFloat("_Y_Move", yMove);

                float xSize = x_Size.value;
                float ySize = y_Size.value;
                material.SetFloat("_X_Size", xSize);
                material.SetFloat("_Y_Size", ySize);
            }
            if (choseNoiseName == 3)
            {
                canvas_Common.enabled = true;
                canvas_PeriodNoise.enabled = true;
                canvas_VoroNoise.enabled = false;
                canvas_SmokeNoise.enabled = false;
                canvas_WorleyNoise.enabled = false;
                canvas_DowntownNoise.enabled = false;
                canvas_DoubleLinerNoise.enabled = false;
                canvas_DumbbellNoise.enabled = false;
                canvas_StepNoise.enabled = false;
                canvas_BrickNoise.enabled = false;
                canvas_WaveletNoise.enabled = false;


                float noiseCloudBrightness = slider_CloudNoiseBrightness.value;
                material.SetFloat("_NoiseBrightness", noiseCloudBrightness);

                float noiseContrast = slider_noise_Contrast.value;
                material.SetFloat("_Noise_Contrast", noiseContrast);

                float noiseSize = float.Parse(inputField_Noise_Size.text);
                material.SetFloat("_Noise_Size", noiseSize);

                float noiseFbmAbsSin_Period = slider_Noise_Period.value;
                material.SetFloat("_Noise_Fbm_Abs_Sin_Period", noiseFbmAbsSin_Period);

                float noiseFbmAbsSin_BreakSize = slider_Noise_BreakSize.value;
                material.SetFloat("_Noise_Fbm_Abs_Sin_BreakSize", noiseFbmAbsSin_BreakSize);

                float xMove = x_Move.value;
                float yMove = y_Move.value;
                material.SetFloat("_X_Move", xMove);
                material.SetFloat("_Y_Move", yMove);

                float xSize = x_Size.value;
                float ySize = y_Size.value;
                material.SetFloat("_X_Size", xSize);
                material.SetFloat("_Y_Size", ySize);
            }
            if (choseNoiseName == 4)
            {
                canvas_Common.enabled = true;
                canvas_PeriodNoise.enabled = false;
                canvas_VoroNoise.enabled = true;
                canvas_SmokeNoise.enabled = false;
                canvas_WorleyNoise.enabled = false;
                canvas_DowntownNoise.enabled = false;
                canvas_DoubleLinerNoise.enabled = false;
                canvas_DumbbellNoise.enabled = false;
                canvas_StepNoise.enabled = false;
                canvas_BrickNoise.enabled = false;
                canvas_WaveletNoise.enabled = false;

                float noiseSelfBrightness = slider_CloudNoiseBrightness.value;
                material.SetFloat("_NoiseBrightness", noiseSelfBrightness);

                float noiseSelfSize = float.Parse(inputField_Noise_Size.text);
                material.SetFloat("_Noise_Size", noiseSelfSize);

                float xMove = x_Move.value;
                float yMove = y_Move.value;
                material.SetFloat("_X_Move", xMove);
                material.SetFloat("_Y_Move", yMove);

                float xSize = x_Size.value;
                float ySize = y_Size.value;
                material.SetFloat("_X_Size", xSize);
                material.SetFloat("_Y_Size", ySize);

                float FormOffsect = slider_VoroNoise_FormOffsect.value;
                material.SetFloat("_FormOffsect", FormOffsect);

                float Fuzzy = slider_VoroNoise_Fuzzy.value;
                material.SetFloat("_Fuzzy", Fuzzy);

                float Form = slider_VoroNoise_Form.value;
                material.SetFloat("_Form", Form);

                float FakeHeight = slider_VoroNoise_FakHeight.value;
                material.SetFloat("_FakeHeight", FakeHeight);

                float RandomSeed = slider_VoroNoise_RandomSeed.value;
                material.SetFloat("_RandomSeed", RandomSeed);
            }

        }
    }
}
