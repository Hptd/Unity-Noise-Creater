using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class SetCountOfBrickNoise : MonoBehaviour
    {
        public Dropdown noiseChose;

        public InputField inputField_Noise_Size;

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

        //BrickNoise
        public Slider slider_BrickNoise_CrackOffset;
        public InputField inputfield_BrickNoise_CrackOffset;
        public Slider slider_BrickNoise_X_CrackWidth;
        public InputField inputfield_BrickNoise_X_CrackWidth;
        public Slider slider_BrickNoise_Y_CrackWidth;
        public InputField inputfield_BrickNoise_Y_CrackWidth;

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
            Initialize(inputfield_x_Move, x_Move);
            Initialize(inputfield_y_Move, y_Move);
            Initialize(inputfield_x_Size, x_Size);
            Initialize(inputfield_y_Size, y_Size);

            //BrickNoise
            Initialize(inputfield_BrickNoise_CrackOffset, slider_BrickNoise_CrackOffset);
            Initialize(inputfield_BrickNoise_X_CrackWidth, slider_BrickNoise_X_CrackWidth);
            Initialize(inputfield_BrickNoise_Y_CrackWidth, slider_BrickNoise_Y_CrackWidth);

            x_Move.onValueChanged.AddListener(this.SliderChange_x_Move);
            inputfield_x_Move.onValueChanged.AddListener(this.InputChange_x_Move);
            y_Move.onValueChanged.AddListener(this.SliderChange_y_Move);
            inputfield_y_Move.onValueChanged.AddListener(this.InputChange_y_Move);
            x_Size.onValueChanged.AddListener(this.SliderChange_x_Size);
            inputfield_x_Size.onValueChanged.AddListener(this.InputChange_x_Size);
            y_Size.onValueChanged.AddListener(this.SliderChange_y_Size);
            inputfield_y_Size.onValueChanged.AddListener(this.InputChange_y_Size);

            //BrickNoise
            slider_BrickNoise_CrackOffset.onValueChanged.AddListener(this.SliderChange_BrickNoise_CrackOffset);
            inputfield_BrickNoise_CrackOffset.onValueChanged.AddListener(this.InputChange_BrickNoise_CrackOffset);
            slider_BrickNoise_X_CrackWidth.onValueChanged.AddListener(this.SliderChange_BrickNoise_X_CrackWidth);
            inputfield_BrickNoise_X_CrackWidth.onValueChanged.AddListener(this.InputChange_BrickNoise_X_CrackWidth);
            slider_BrickNoise_Y_CrackWidth.onValueChanged.AddListener(this.SliderChange_BrickNoise_Y_CrackWidth);
            inputfield_BrickNoise_Y_CrackWidth.onValueChanged.AddListener(this.InputChange_BrickNoise_Y_CrackWidth);
        }

        //初始化参数
        void Initialize(InputField inputField, Slider slider)
        {
            inputField.text = slider.value.ToString();
        }
        //Slider To InputField
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
            //BrickNoise特性参数
        void SliderChange_BrickNoise_CrackOffset(float value)
        {
            inputfield_BrickNoise_CrackOffset.text = slider_BrickNoise_CrackOffset.value.ToString();
        }
        void SliderChange_BrickNoise_X_CrackWidth(float value)
        {
            inputfield_BrickNoise_X_CrackWidth.text = slider_BrickNoise_X_CrackWidth.value.ToString();
        }
        void SliderChange_BrickNoise_Y_CrackWidth(float value)
        {
            inputfield_BrickNoise_Y_CrackWidth.text = slider_BrickNoise_Y_CrackWidth.value.ToString();
        }

        //InputField To Slider
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
            //BrickNoise特性参数
        void InputChange_BrickNoise_CrackOffset(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_BrickNoise_CrackOffset.maxValue)
            {
                slider_BrickNoise_CrackOffset.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_BrickNoise_CrackOffset.maxValue)
            {
                slider_BrickNoise_CrackOffset.maxValue = float.Parse(va);
                slider_BrickNoise_CrackOffset.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_BrickNoise_CrackOffset.minValue)
            {
                slider_BrickNoise_CrackOffset.minValue = float.Parse(va);
                slider_BrickNoise_CrackOffset.value = float.Parse(va);
            }
        }
        void InputChange_BrickNoise_X_CrackWidth(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_BrickNoise_X_CrackWidth.maxValue)
            {
                slider_BrickNoise_X_CrackWidth.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_BrickNoise_X_CrackWidth.maxValue)
            {
                slider_BrickNoise_X_CrackWidth.maxValue = float.Parse(va);
                slider_BrickNoise_X_CrackWidth.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_BrickNoise_X_CrackWidth.minValue)
            {
                slider_BrickNoise_X_CrackWidth.minValue = float.Parse(va);
                slider_BrickNoise_X_CrackWidth.value = float.Parse(va);
            }
        }
        void InputChange_BrickNoise_Y_CrackWidth(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= slider_BrickNoise_Y_CrackWidth.maxValue)
            {
                slider_BrickNoise_Y_CrackWidth.value = float.Parse(va);
            }
            if (float.Parse(va) > slider_BrickNoise_Y_CrackWidth.maxValue)
            {
                slider_BrickNoise_Y_CrackWidth.maxValue = float.Parse(va);
                slider_BrickNoise_Y_CrackWidth.value = float.Parse(va);
            }
            if (float.Parse(va) < slider_BrickNoise_Y_CrackWidth.minValue)
            {
                slider_BrickNoise_Y_CrackWidth.minValue = float.Parse(va);
                slider_BrickNoise_Y_CrackWidth.value = float.Parse(va);
            }
        }
        void Update()
        {
            choseNoiseName = noiseChose.GetComponent<Dropdown>().value;

            material.SetInt("_ChoseNoiseNumber", choseNoiseName);
        }
        void FixedUpdate()
        {
            if (choseNoiseName == 11)
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
                canvas_BrickNoise.enabled = true;
                canvas_WaveletNoise.enabled = false;

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

                float brickNoise_CrackOffset = slider_BrickNoise_CrackOffset.value;
                material.SetFloat("_BrickNoise_CrackOffset", brickNoise_CrackOffset);
                float brickNoise_X_CrackWidth = slider_BrickNoise_X_CrackWidth.value;
                material.SetFloat("_BrickNoise_X_CrackWidth", brickNoise_X_CrackWidth);
                float brickNoise_Y_CrackWidth = slider_BrickNoise_Y_CrackWidth.value;
                material.SetFloat("_BrickNoise_Y_CrackWidth", brickNoise_Y_CrackWidth);
            }
        }
    }
}
