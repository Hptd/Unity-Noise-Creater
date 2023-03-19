using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class SetCountOfStepNoise : MonoBehaviour
    {
        public Dropdown noiseChose;

        public InputField inputField_Noise_Size;
        public Slider slider_noise_Contrast;
        public InputField inputfield_noise_Contrast;

        public Slider slider_CloudNoiseBrightness;
        public InputField inputfield_CloudNoiseBrightness;

        public Material material;
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

        //StepNoise特性参数
        public Slider slider_StepNoise_Boundary_1;
        public InputField inputfield_StepNoise_Boundary_1;
        public Slider slider_StepNoise_Boundary_2;
        public InputField inputfield_StepNoise_Boundary_2;
        public Slider slider_StepNoise_Boundary_3;
        public InputField inputfield_StepNoise_Boundary_3;

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

        void Start()
        {
            //input.text = slider.value.ToString();    //初始化
            Initialize(inputfield_noise_Contrast, slider_noise_Contrast);
            Initialize(inputfield_CloudNoiseBrightness, slider_CloudNoiseBrightness);
            Initialize(inputfield_x_Move, x_Move);
            Initialize(inputfield_y_Move, y_Move);
            Initialize(inputfield_x_Size, x_Size);
            Initialize(inputfield_y_Size, y_Size);

            //StepNoise特效参数双模调整
            Initialize(inputfield_StepNoise_Boundary_1, slider_StepNoise_Boundary_1);
            Initialize(inputfield_StepNoise_Boundary_2, slider_StepNoise_Boundary_2);
            Initialize(inputfield_StepNoise_Boundary_3, slider_StepNoise_Boundary_3);

            slider_noise_Contrast.onValueChanged.AddListener(this.SliderChange_Contrast);
            inputfield_noise_Contrast.onValueChanged.AddListener(this.InputChange_Contrast);
            slider_CloudNoiseBrightness.onValueChanged.AddListener(this.SliderChange_CloudNoiseBrightness);
            inputfield_CloudNoiseBrightness.onValueChanged.AddListener(this.InputChange_CloudNoiseBrightness);
            x_Move.onValueChanged.AddListener(this.SliderChange_x_Move);
            inputfield_x_Move.onValueChanged.AddListener(this.InputChange_x_Move);
            y_Move.onValueChanged.AddListener(this.SliderChange_y_Move);
            inputfield_y_Move.onValueChanged.AddListener(this.InputChange_y_Move);
            x_Size.onValueChanged.AddListener(this.SliderChange_x_Size);
            inputfield_x_Size.onValueChanged.AddListener(this.InputChange_x_Size);
            y_Size.onValueChanged.AddListener(this.SliderChange_y_Size);
            inputfield_y_Size.onValueChanged.AddListener(this.InputChange_y_Size);

            //StepNoise特效参数双模调整
            slider_StepNoise_Boundary_1.onValueChanged.AddListener(this.SliderChange_StepNoise_Boundary_1);
            inputfield_StepNoise_Boundary_1.onValueChanged.AddListener(this.InputChange_StepNoise_Boundary_1);
            slider_StepNoise_Boundary_2.onValueChanged.AddListener(this.SliderChange_StepNoise_Boundary_2);
            inputfield_StepNoise_Boundary_2.onValueChanged.AddListener(this.InputChange_StepNoise_Boundary_2);
            slider_StepNoise_Boundary_3.onValueChanged.AddListener(this.SliderChange_StepNoise_Boundary_3);
            inputfield_StepNoise_Boundary_3.onValueChanged.AddListener(this.InputChange_StepNoise_Boundary_3);
        }
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

            //StepNoise特效参数
        void SliderChange_StepNoise_Boundary_1(float value)
        {
            inputfield_StepNoise_Boundary_1.text = slider_StepNoise_Boundary_1.value.ToString();
        }
        void SliderChange_StepNoise_Boundary_2(float value)
        {
            inputfield_StepNoise_Boundary_2.text = slider_StepNoise_Boundary_2.value.ToString();
        }
        void SliderChange_StepNoise_Boundary_3(float value)
        {
            inputfield_StepNoise_Boundary_3.text = slider_StepNoise_Boundary_3.value.ToString();
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

            //StepNoise特效参数
        void InputChange_StepNoise_Boundary_1(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_StepNoise_Boundary_1.maxValue)
            {
                slider_StepNoise_Boundary_1.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_StepNoise_Boundary_1.maxValue)
            {
                slider_StepNoise_Boundary_1.maxValue = float.Parse(va);
                slider_StepNoise_Boundary_1.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_StepNoise_Boundary_1.minValue)
            {
                slider_StepNoise_Boundary_1.minValue = float.Parse(va);
                slider_StepNoise_Boundary_1.value = float.Parse(va);
            }
        }
        void InputChange_StepNoise_Boundary_2(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_StepNoise_Boundary_2.maxValue)
            {
                slider_StepNoise_Boundary_2.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_StepNoise_Boundary_2.maxValue)
            {
                slider_StepNoise_Boundary_2.maxValue = float.Parse(va);
                slider_StepNoise_Boundary_2.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_StepNoise_Boundary_2.minValue)
            {
                slider_StepNoise_Boundary_2.minValue = float.Parse(va);
                slider_StepNoise_Boundary_2.value = float.Parse(va);
            }
        }
        void InputChange_StepNoise_Boundary_3(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_StepNoise_Boundary_3.maxValue)
            {
                slider_StepNoise_Boundary_3.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_StepNoise_Boundary_3.maxValue)
            {
                slider_StepNoise_Boundary_3.maxValue = float.Parse(va);
                slider_StepNoise_Boundary_3.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_StepNoise_Boundary_3.minValue)
            {
                slider_StepNoise_Boundary_3.minValue = float.Parse(va);
                slider_StepNoise_Boundary_3.value = float.Parse(va);
            }
        }

        void Update()
        {
            choseNoiseName = noiseChose.GetComponent<Dropdown>().value;

            material.SetInt("_ChoseNoiseNumber", choseNoiseName);
        }

        private void FixedUpdate()
        {
            if (choseNoiseName == 10)
            {
                canvas_Common.enabled = true;
                canvas_PeriodNoise.enabled = false;
                canvas_VoroNoise.enabled = false;
                canvas_SmokeNoise.enabled = false;
                canvas_WorleyNoise.enabled = false;
                canvas_DowntownNoise.enabled = false;
                canvas_DoubleLinerNoise.enabled = false;
                canvas_DumbbellNoise.enabled = false;
                canvas_StepNoise.enabled = true;
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

                //StepNoise特性参数
                float stepNoise_Boundary_1 = slider_StepNoise_Boundary_1.value;
                material.SetFloat("_StepNoise_Step_1", stepNoise_Boundary_1);
                float stepNoise_Boundary_2 = slider_StepNoise_Boundary_2.value;
                material.SetFloat("_StepNoise_Step_2", stepNoise_Boundary_2);
                float stepNoise_Boundary_3 = slider_StepNoise_Boundary_3.value;
                material.SetFloat("_StepNoise_Step_3", stepNoise_Boundary_3);
            }
        }
    }
}
