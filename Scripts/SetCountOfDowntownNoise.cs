using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class SetCountOfDowntownNoise : MonoBehaviour
    {
        public Material material;

        public Dropdown noiseChose;
        //公共参数
        public InputField inputField_Noise_Size;
        public Slider slider_noise_Contrast;
        public InputField inputfield_noise_Contrast;
        public Slider slider_CloudNoiseBrightness;
        public InputField inputfield_CloudNoiseBrightness;
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

        //DowntownNoise
        public Slider slider_DowntownNoise_Level;
        public InputField inputfield_DowntownNoise_Level;
        public Slider slider_DowntownNoise_LevelBreakSize;
        public InputField inputfield_DowntownNoise_LevelBreakSize;
        public Slider slider_DowntownNoise_LayersMove;
        public InputField inputfield_DowntownNoise_LayersMove;
        public Slider slider_DowntownNoise_RandomSeed;
        public InputField inputfield_DowntownNoise_RandomSeed;

        public Canvas canvas_Common;
        public Canvas canvas_PeriodNoise;
        public Canvas canvas_SmokeNoise;
        public Canvas canvas_VoroNoise;
        public Canvas canvas_WorleyNoise;
        public Canvas canvas_DowntownNoise;
        public Canvas canvas_DoubleLinerNoise;
        public Canvas canvas_DumbbellNoise;
        public Canvas canvas_StepNoise;
        public Canvas canvas_BrickNoise;
        public Canvas canvas_WaveletNoise;

        private int choseNoiseName = 0;

        void Start()
        {
            Initialize(inputfield_noise_Contrast, slider_noise_Contrast);
            Initialize(inputfield_CloudNoiseBrightness, slider_CloudNoiseBrightness);
            Initialize(inputfield_x_Move, x_Move);
            Initialize(inputfield_y_Move, y_Move);
            Initialize(inputfield_x_Size, x_Size);
            Initialize(inputfield_y_Size, y_Size);
            //DowntownNoise特性参数
            Initialize(inputfield_DowntownNoise_Level, slider_DowntownNoise_Level);
            Initialize(inputfield_DowntownNoise_LevelBreakSize, slider_DowntownNoise_LevelBreakSize);
            Initialize(inputfield_DowntownNoise_LayersMove, slider_DowntownNoise_LayersMove);
            Initialize(inputfield_DowntownNoise_RandomSeed, slider_DowntownNoise_RandomSeed);

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
            //DowntownNoise特性参数
            slider_DowntownNoise_Level.onValueChanged.AddListener(this.SliderChange_DowntownNoise_Level);
            inputfield_DowntownNoise_Level.onValueChanged.AddListener(this.InputChange_DowntownNoise_Level);
            slider_DowntownNoise_LevelBreakSize.onValueChanged.AddListener(this.SliderChange_DowntownNoise_LevelBreakSize);
            inputfield_DowntownNoise_LevelBreakSize.onValueChanged.AddListener(this.InputChange_DowntownNoise_LevelBreakSize);
            slider_DowntownNoise_LayersMove.onValueChanged.AddListener(this.SliderChange_DowntownNoise_LayersMove);
            inputfield_DowntownNoise_LayersMove.onValueChanged.AddListener(this.InputChange_DowntownNoise_LayersMove);
            slider_DowntownNoise_RandomSeed.onValueChanged.AddListener(this.SliderChange_DowntownNoise_RandomSeed);
            inputfield_DowntownNoise_RandomSeed.onValueChanged.AddListener(this.InputChange_DowntownNoise_RandomSeed);
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
        //DowntownNoise特性参数
        void InputChange_DowntownNoise_Level(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DowntownNoise_Level.maxValue)
            {
                slider_DowntownNoise_Level.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_DowntownNoise_Level.maxValue)
            {
                slider_DowntownNoise_Level.maxValue = float.Parse(va);
                slider_DowntownNoise_Level.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_DowntownNoise_Level.minValue)
            {
                slider_DowntownNoise_Level.minValue = float.Parse(va);
                slider_DowntownNoise_Level.value = float.Parse(va);
            }
        }
        void InputChange_DowntownNoise_LevelBreakSize(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DowntownNoise_LevelBreakSize.maxValue)
            {
                slider_DowntownNoise_LevelBreakSize.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_DowntownNoise_LevelBreakSize.maxValue)
            {
                slider_DowntownNoise_LevelBreakSize.maxValue = float.Parse(va);
                slider_DowntownNoise_LevelBreakSize.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_DowntownNoise_LevelBreakSize.minValue)
            {
                slider_DowntownNoise_LevelBreakSize.minValue = float.Parse(va);
                slider_DowntownNoise_LevelBreakSize.value = float.Parse(va);
            }
        }
        void InputChange_DowntownNoise_LayersMove(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DowntownNoise_LayersMove.maxValue)
            {
                slider_DowntownNoise_LayersMove.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_DowntownNoise_LayersMove.maxValue)
            {
                slider_DowntownNoise_LayersMove.maxValue = float.Parse(va);
                slider_DowntownNoise_LayersMove.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_DowntownNoise_LayersMove.minValue)
            {
                slider_DowntownNoise_LayersMove.minValue = float.Parse(va);
                slider_DowntownNoise_LayersMove.value = float.Parse(va);
            }
        }
        void InputChange_DowntownNoise_RandomSeed(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DowntownNoise_RandomSeed.maxValue)
            {
                slider_DowntownNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_DowntownNoise_RandomSeed.maxValue)
            {
                slider_DowntownNoise_RandomSeed.maxValue = float.Parse(va);
                slider_DowntownNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_DowntownNoise_RandomSeed.minValue)
            {
                slider_DowntownNoise_RandomSeed.minValue = float.Parse(va);
                slider_DowntownNoise_RandomSeed.value = float.Parse(va);
            }
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
        //DowntownNoise特性参数
        void SliderChange_DowntownNoise_Level(float value)
        {
            inputfield_DowntownNoise_Level.text = slider_DowntownNoise_Level.value.ToString();
        }
        void SliderChange_DowntownNoise_LevelBreakSize(float value)
        {
            inputfield_DowntownNoise_LevelBreakSize.text = slider_DowntownNoise_LevelBreakSize.value.ToString();
        }
        void SliderChange_DowntownNoise_LayersMove(float value)
        {
            inputfield_DowntownNoise_LayersMove.text = slider_DowntownNoise_LayersMove.value.ToString();
        }
        void SliderChange_DowntownNoise_RandomSeed(float value)
        {
            inputfield_DowntownNoise_RandomSeed.text = slider_DowntownNoise_RandomSeed.value.ToString();
        }

        void Initialize(InputField inputField, Slider slider)
        {
            inputField.text = slider.value.ToString();
        }
        void Update()
        {
            choseNoiseName = noiseChose.GetComponent<Dropdown>().value;

            material.SetInt("_ChoseNoiseNumber", choseNoiseName);
        }
        private void FixedUpdate()
        {
            if (choseNoiseName == 7)
            {
                canvas_Common.enabled = true;
                canvas_PeriodNoise.enabled = false;
                canvas_VoroNoise.enabled = false;
                canvas_SmokeNoise.enabled = false;
                canvas_WorleyNoise.enabled = false;
                canvas_DowntownNoise.enabled = true;
                canvas_DoubleLinerNoise.enabled = false;
                canvas_DumbbellNoise.enabled = false;
                canvas_StepNoise.enabled = false;
                canvas_BrickNoise.enabled = false;
                canvas_WaveletNoise.enabled = false;

                float noiseSelfContrast = slider_noise_Contrast.value;
                material.SetFloat("_Noise_Contrast", noiseSelfContrast);

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

                float downtownNoise_Level = slider_DowntownNoise_Level.value;
                material.SetFloat("_DowntownNoise_Level", downtownNoise_Level);

                float downtown_LevelBreakSize = slider_DowntownNoise_LevelBreakSize.value;
                material.SetFloat("_DowntownNoise_LevelBreakSize", downtown_LevelBreakSize);

                float downtownNoise_LayersMove = slider_DowntownNoise_LayersMove.value;
                material.SetFloat("_DowntownNoise_LayersMove", downtownNoise_LayersMove);

                float downtownNoise_RandomSeed = slider_DowntownNoise_RandomSeed.value;
                material.SetFloat("_DowntownNoise_RandomSeed", downtownNoise_RandomSeed);
            }
        }
    }
}
