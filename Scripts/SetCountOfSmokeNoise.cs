using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class SetCountOfSmokeNoise : MonoBehaviour
    {
        public Material material;

        public Dropdown noiseChose;
        //公共参数
        public InputField inputField_Noise_Size;
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

        //SmokeNoise
        public Slider slider_SmokeNoise_FormOffsect;
        public InputField inputfield_SmokeNoise_FormOffsect;
        public Slider slider_SmokeNoise_Curvature;
        public InputField inputfield_SmokeNoise_Curvature;
        public Slider slider_SmokeNoise_Level;
        public InputField inputfield_SmokeNoise_Level;
        public Slider slider_SmokeNoise_Particle;
        public InputField inputfield_SmokeNoise_Particle;
        public Slider slider_SmokeNoise_MoveLevel;
        public InputField inputfield_SmokeNoise_MoveLevel;
        public Slider slider_SmokeNoise_RandomSeed;
        public InputField inputfield_SmokeNoise_RandomSeed;

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
            Initialize(inputfield_CloudNoiseBrightness, slider_CloudNoiseBrightness);
            Initialize(inputfield_x_Move, x_Move);
            Initialize(inputfield_y_Move, y_Move);
            Initialize(inputfield_x_Size, x_Size);
            Initialize(inputfield_y_Size, y_Size);
            //SmokeNoise特性参数
            Initialize(inputfield_SmokeNoise_FormOffsect, slider_SmokeNoise_FormOffsect);
            Initialize(inputfield_SmokeNoise_Curvature, slider_SmokeNoise_Curvature);
            Initialize(inputfield_SmokeNoise_Level, slider_SmokeNoise_Level);
            Initialize(inputfield_SmokeNoise_Particle, slider_SmokeNoise_Particle);
            Initialize(inputfield_SmokeNoise_MoveLevel, slider_SmokeNoise_MoveLevel);
            Initialize(inputfield_SmokeNoise_RandomSeed, slider_SmokeNoise_RandomSeed);

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
            //SmokeNoise特性参数
            slider_SmokeNoise_FormOffsect.onValueChanged.AddListener(this.SliderChange_SmokeNoise_FormOffsect);
            inputfield_SmokeNoise_FormOffsect.onValueChanged.AddListener(this.InputChange_SmokeNoise_FormOffsect);
            slider_SmokeNoise_Curvature.onValueChanged.AddListener(this.SliderChange_SmokeNoise_Curvature);
            inputfield_SmokeNoise_Curvature.onValueChanged.AddListener(this.InputChange_SmokeNoise_Curvature);
            slider_SmokeNoise_Level.onValueChanged.AddListener(this.SliderChange_SmokeNoise_Level);
            inputfield_SmokeNoise_Level.onValueChanged.AddListener(this.InputChange_SmokeNoise_Level);
            slider_SmokeNoise_Particle.onValueChanged.AddListener(this.SliderChange_SmokeNoise_Particle);
            inputfield_SmokeNoise_Particle.onValueChanged.AddListener(this.InputChange_SmokeNoise_Particle);
            slider_SmokeNoise_MoveLevel.onValueChanged.AddListener(this.SliderChange_SmokeNoise_MoveLevel);
            inputfield_SmokeNoise_MoveLevel.onValueChanged.AddListener(this.InputChange_SmokeNoise_MoveLevel);
            slider_SmokeNoise_RandomSeed.onValueChanged.AddListener(this.SliderChange_SmokeNoise_RandomSeed);
            inputfield_SmokeNoise_RandomSeed.onValueChanged.AddListener(this.InputChange_SmokeNoise_RandomSeed);
        }
        //InoutField 2 Slider
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
        //SmokeNoise特性参数
        void InputChange_SmokeNoise_FormOffsect(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_SmokeNoise_FormOffsect.maxValue)
            {
                slider_SmokeNoise_FormOffsect.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_SmokeNoise_FormOffsect.maxValue)
            {
                slider_SmokeNoise_FormOffsect.maxValue = float.Parse(va);
                slider_SmokeNoise_FormOffsect.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_SmokeNoise_FormOffsect.minValue)
            {
                slider_SmokeNoise_FormOffsect.minValue = float.Parse(va);
                slider_SmokeNoise_FormOffsect.value = float.Parse(va);
            }
        }
        void InputChange_SmokeNoise_Curvature(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_SmokeNoise_Curvature.maxValue)
            {
                slider_SmokeNoise_Curvature.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_SmokeNoise_Curvature.maxValue)
            {
                slider_SmokeNoise_Curvature.maxValue = float.Parse(va);
                slider_SmokeNoise_Curvature.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_SmokeNoise_Curvature.minValue)
            {
                slider_SmokeNoise_Curvature.minValue = float.Parse(va);
                slider_SmokeNoise_Curvature.value = float.Parse(va);
            }
        }
        void InputChange_SmokeNoise_Level(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_SmokeNoise_Level.maxValue)
            {
                slider_SmokeNoise_Level.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_SmokeNoise_Level.maxValue)
            {
                slider_SmokeNoise_Level.maxValue = float.Parse(va);
                slider_SmokeNoise_Level.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_SmokeNoise_Level.minValue)
            {
                slider_SmokeNoise_Level.minValue = float.Parse(va);
                slider_SmokeNoise_Level.value = float.Parse(va);
            }
        }
        void InputChange_SmokeNoise_Particle(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_SmokeNoise_Particle.maxValue)
            {
                slider_SmokeNoise_Particle.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_SmokeNoise_Particle.maxValue)
            {
                slider_SmokeNoise_Particle.maxValue = float.Parse(va);
                slider_SmokeNoise_Particle.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_SmokeNoise_Particle.minValue)
            {
                slider_SmokeNoise_Particle.minValue = float.Parse(va);
                slider_SmokeNoise_Particle.value = float.Parse(va);
            }
        }
        void InputChange_SmokeNoise_MoveLevel(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_SmokeNoise_MoveLevel.maxValue)
            {
                slider_SmokeNoise_MoveLevel.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_SmokeNoise_MoveLevel.maxValue)
            {
                slider_SmokeNoise_MoveLevel.maxValue = float.Parse(va);
                slider_SmokeNoise_MoveLevel.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_SmokeNoise_MoveLevel.minValue)
            {
                slider_SmokeNoise_MoveLevel.minValue = float.Parse(va);
                slider_SmokeNoise_MoveLevel.value = float.Parse(va);
            }
        }
        void InputChange_SmokeNoise_RandomSeed(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_SmokeNoise_RandomSeed.maxValue)
            {
                slider_SmokeNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_SmokeNoise_RandomSeed.maxValue)
            {
                slider_SmokeNoise_RandomSeed.maxValue = float.Parse(va);
                slider_SmokeNoise_RandomSeed.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_SmokeNoise_RandomSeed.minValue)
            {
                slider_SmokeNoise_RandomSeed.minValue = float.Parse(va);
                slider_SmokeNoise_RandomSeed.value = float.Parse(va);
            }
        }

        //Slider 2 InoutField
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
        //SmokeNoise特性参数
        void SliderChange_SmokeNoise_FormOffsect(float value)
        {
            inputfield_SmokeNoise_FormOffsect.text = slider_SmokeNoise_FormOffsect.value.ToString();
        }
        void SliderChange_SmokeNoise_Curvature(float value)
        {
            inputfield_SmokeNoise_Curvature.text = slider_SmokeNoise_Curvature.value.ToString();
        }
        void SliderChange_SmokeNoise_Level(float value)
        {
            inputfield_SmokeNoise_Level.text = slider_SmokeNoise_Level.value.ToString();
        }
        void SliderChange_SmokeNoise_Particle(float value)
        {
            inputfield_SmokeNoise_Particle.text = slider_SmokeNoise_Particle.value.ToString();
        }
        void SliderChange_SmokeNoise_MoveLevel(float value)
        {
            inputfield_SmokeNoise_MoveLevel.text = slider_SmokeNoise_MoveLevel.value.ToString();
        }
        void SliderChange_SmokeNoise_RandomSeed(float value)
        {
            inputfield_SmokeNoise_RandomSeed.text = slider_SmokeNoise_RandomSeed.value.ToString();
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
            if (choseNoiseName == 5)
            {
                canvas_Common.enabled = true;
                canvas_PeriodNoise.enabled = false;
                canvas_VoroNoise.enabled = false;
                canvas_SmokeNoise.enabled = true;
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

                float smokeNoise_FormOffsect = slider_SmokeNoise_FormOffsect.value;
                material.SetFloat("_SmokeNoise_FormOffsect", smokeNoise_FormOffsect);

                float smokeNoise_Curvature = slider_SmokeNoise_Curvature.value;
                material.SetFloat("_SmokeNoise_Curvature", smokeNoise_Curvature);

                float smokeNoise_Level = slider_SmokeNoise_Level.value;
                material.SetFloat("_SmokeNoise_Level", smokeNoise_Level);

                float smokeNoise_Particle = slider_SmokeNoise_Particle.value;
                material.SetFloat("_SmokeNoise_Particle", smokeNoise_Particle);

                float smokeNoise_MoveLevel = slider_SmokeNoise_MoveLevel.value;
                material.SetFloat("_SmokeNoise_MoveLevel", smokeNoise_MoveLevel);

                float smokeNoise_RandomSeed = slider_SmokeNoise_RandomSeed.value;
                material.SetFloat("_SmokeNoise_RandomSeed", smokeNoise_RandomSeed);
            }
        }
    }
}
