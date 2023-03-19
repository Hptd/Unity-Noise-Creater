using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class SetCountOfWaveletNoise : MonoBehaviour
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

        //WaveletNoise特性参数
        public Slider slider_WaveletNoise_NoiseLayer;
        public InputField inputfield_WaveletNoise_NoiseLayer;
        public Slider slider_WaveletNoise_SharpPower;
        public InputField inputfield_WaveletNoise_SharpPower;
        public Slider slider_WaveletNoise_FormChange;
        public InputField inputfield_WaveletNoise_FormChange;
        public Slider slider_WaveletNoise_RandomSeed;
        public InputField inputfield_WaveletNoise_RandomSeed;

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
            Initialize(inputfield_x_Move, x_Move);
            Initialize(inputfield_y_Move, y_Move);
            Initialize(inputfield_x_Size, x_Size);
            Initialize(inputfield_y_Size, y_Size);

            //WaveletNoise特性参数
            Initialize(inputfield_WaveletNoise_NoiseLayer, slider_WaveletNoise_NoiseLayer);
            Initialize(inputfield_WaveletNoise_SharpPower, slider_WaveletNoise_SharpPower);
            Initialize(inputfield_WaveletNoise_FormChange, slider_WaveletNoise_FormChange);
            Initialize(inputfield_WaveletNoise_RandomSeed, slider_WaveletNoise_RandomSeed);

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

            //WaveletNoise特性参数
            slider_WaveletNoise_NoiseLayer.onValueChanged.AddListener(this.SliderChange_WaveletNoise_NoiseLayer);
            inputfield_WaveletNoise_NoiseLayer.onValueChanged.AddListener(this.InputChange_WaveletNoise_NoiseLayer);
            slider_WaveletNoise_SharpPower.onValueChanged.AddListener(this.SliderChange_WaveletNoise_SharpPower);
            inputfield_WaveletNoise_SharpPower.onValueChanged.AddListener(this.InputChange_WaveletNoise_SharpPower);
            slider_WaveletNoise_FormChange.onValueChanged.AddListener(this.SliderChange_WaveletNoise_FormChange);
            inputfield_WaveletNoise_FormChange.onValueChanged.AddListener(this.InputChange_WaveletNoise_FormChange);
            slider_WaveletNoise_RandomSeed.onValueChanged.AddListener(this.SliderChange_WaveletNoise_RandomSeed);
            inputfield_WaveletNoise_RandomSeed.onValueChanged.AddListener(this.InputChange_WaveletNoise_RandomSeed);
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

        //WaveletNoise
        void SliderChange_WaveletNoise_NoiseLayer(float value)
        {
            inputfield_WaveletNoise_NoiseLayer.text = slider_WaveletNoise_NoiseLayer.value.ToString();
        }
        void SliderChange_WaveletNoise_SharpPower(float value)
        {
            inputfield_WaveletNoise_SharpPower.text = slider_WaveletNoise_SharpPower.value.ToString();
        }
        void SliderChange_WaveletNoise_FormChange(float value)
        {
            inputfield_WaveletNoise_FormChange.text = slider_WaveletNoise_FormChange.value.ToString();
        }
        void SliderChange_WaveletNoise_RandomSeed(float value)
        {
            inputfield_WaveletNoise_RandomSeed.text = slider_WaveletNoise_RandomSeed.value.ToString();
        }

        void InputChange_WaveletNoise_NoiseLayer(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_WaveletNoise_NoiseLayer.maxValue)
            {
                slider_WaveletNoise_NoiseLayer.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_WaveletNoise_NoiseLayer.maxValue)
            {
                slider_WaveletNoise_NoiseLayer.maxValue = float.Parse(va);
                slider_WaveletNoise_NoiseLayer.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_WaveletNoise_NoiseLayer.minValue)
            {
                slider_WaveletNoise_NoiseLayer.minValue = float.Parse(va);
                slider_WaveletNoise_NoiseLayer.value = float.Parse(va);
            }
        }
        void InputChange_WaveletNoise_SharpPower(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_WaveletNoise_SharpPower.maxValue)
            {
                slider_WaveletNoise_SharpPower.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_WaveletNoise_SharpPower.maxValue)
            {
                slider_WaveletNoise_SharpPower.maxValue = float.Parse(va);
                slider_WaveletNoise_SharpPower.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_WaveletNoise_SharpPower.minValue)
            {
                slider_WaveletNoise_SharpPower.minValue = float.Parse(va);
                slider_WaveletNoise_SharpPower.value = float.Parse(va);
            }
        }
        void InputChange_WaveletNoise_FormChange(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_WaveletNoise_FormChange.maxValue)
            {
                slider_WaveletNoise_FormChange.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_WaveletNoise_FormChange.maxValue)
            {
                slider_WaveletNoise_FormChange.maxValue = float.Parse(va);
                slider_WaveletNoise_FormChange.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_WaveletNoise_FormChange.minValue)
            {
                slider_WaveletNoise_FormChange.minValue = float.Parse(va);
                slider_WaveletNoise_FormChange.value = float.Parse(va);
            }
        }
        void InputChange_WaveletNoise_RandomSeed(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_WaveletNoise_RandomSeed.maxValue)
            {
                slider_WaveletNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_WaveletNoise_RandomSeed.maxValue)
            {
                slider_WaveletNoise_RandomSeed.maxValue = float.Parse(va);
                slider_WaveletNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_WaveletNoise_RandomSeed.minValue)
            {
                slider_WaveletNoise_RandomSeed.minValue = float.Parse(va);
                slider_WaveletNoise_RandomSeed.value = float.Parse(va);
            }
        }

        void Update()
        {
            choseNoiseName = noiseChose.GetComponent<Dropdown>().value;

            material.SetInt("_ChoseNoiseNumber", choseNoiseName);
        }

        private void FixedUpdate()
        {
            if (choseNoiseName == 12)
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
                canvas_WaveletNoise.enabled = true;

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

                float waveletNoise_NoiseLayer = slider_WaveletNoise_NoiseLayer.value;
                material.SetFloat("_WaveletNoise_NoiseLayer", waveletNoise_NoiseLayer);

                float waveletNoise_SharpPower = slider_WaveletNoise_SharpPower.value;
                material.SetFloat("_WaveletNoise_SharpPower", waveletNoise_SharpPower);

                float waveletNoise_FormChange = slider_WaveletNoise_FormChange.value;
                material.SetFloat("_WaveletNoise_FormChange", waveletNoise_FormChange);

                float waveletNoise_RandomSeed = slider_WaveletNoise_RandomSeed.value;
                material.SetFloat("_WaveletNoise_RandomSeed", waveletNoise_RandomSeed);
            }
        }
    }
}
