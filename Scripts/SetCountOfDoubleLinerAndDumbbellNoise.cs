using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetCountOfDoubleLinerAndDumbbellNoise : MonoBehaviour
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

    //DoubleLinerNoise
    public Slider slider_DoubleLinerNoise_Thickness;
    public InputField inputfield_DoubleLinerNoise_Thickness;
    public Slider slider_DoubleLinerNoise_SingleOffset;
    public InputField inputfield_DoubleLinerNoise_SingleOffset;
    public Slider slider_DoubleLinerNoise_SingleRot;
    public InputField inputfield_DoubleLinerNoise_SingleRot;
    public Slider slider_DoubleLinerNoise_DoubleRot;
    public InputField inputfield_DoubleLinerNoise_DoubleRot;
    public Slider slider_DoubleLinerNoise_RandomSeed;
    public InputField inputfield_DoubleLinerNoise_RandomSeed;

    //DumbbellNoise
    public Slider slider_DumbbellNoise_GrayCut;
    public InputField inputfield_DumbbellNoise_GrayCut;
    public Slider slider_DumbbellNoise_BrightnessCut;
    public InputField inputfield_DumbbellNoise_BrightnessCut;
    public Slider slider_DumbbellNoise_SideSize_1;
    public InputField inputfield_DumbbellNoise_SideSize_1;
    public Slider slider_DumbbellNoise_SideSize_2;
    public InputField inputfield_DumbbellNoise_SideSize_2;
    public Slider slider_DumbbellNoise_GraphicsDislocation_1;
    public InputField inputfield_DumbbellNoise_GraphicsDislocation_1;
    public Slider slider_DumbbellNoise_GraphicsDislocation_2;
    public InputField inputfield_DumbbellNoise_GraphicsDislocation_2;
    public Slider slider_DumbbellNoise_Direction;
    public InputField inputfield_DumbbellNoise_Direction;
    public Slider slider_DumbbellNoise_RandomSeed;
    public InputField inputfield_DumbbellNoise_RandomSeed;

    //Canvas
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

        //DoubleLinerNoise特性参数
        Initialize(inputfield_DoubleLinerNoise_Thickness, slider_DoubleLinerNoise_Thickness);
        Initialize(inputfield_DoubleLinerNoise_SingleOffset, slider_DoubleLinerNoise_SingleOffset);
        Initialize(inputfield_DoubleLinerNoise_SingleRot, slider_DoubleLinerNoise_SingleRot);
        Initialize(inputfield_DoubleLinerNoise_DoubleRot, slider_DoubleLinerNoise_DoubleRot);
        Initialize(inputfield_DoubleLinerNoise_RandomSeed, slider_DoubleLinerNoise_RandomSeed);

        //DumbbellNoise特性参数
        Initialize(inputfield_DumbbellNoise_GrayCut, slider_DumbbellNoise_GrayCut);
        Initialize(inputfield_DumbbellNoise_BrightnessCut, slider_DumbbellNoise_BrightnessCut);
        Initialize(inputfield_DumbbellNoise_SideSize_1, slider_DumbbellNoise_SideSize_1);
        Initialize(inputfield_DumbbellNoise_SideSize_2, slider_DumbbellNoise_SideSize_2);
        Initialize(inputfield_DumbbellNoise_GraphicsDislocation_1, slider_DumbbellNoise_GraphicsDislocation_1);
        Initialize(inputfield_DumbbellNoise_GraphicsDislocation_2, slider_DumbbellNoise_GraphicsDislocation_2);
        Initialize(inputfield_DumbbellNoise_Direction, slider_DumbbellNoise_Direction);
        Initialize(inputfield_DumbbellNoise_RandomSeed, slider_DumbbellNoise_RandomSeed);

        //监听数据
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

            //DoubleLinerNoise特性参数
        slider_DoubleLinerNoise_Thickness.onValueChanged.AddListener(this.SliderChange_DoubleLinerNoise_Thickness);
        inputfield_DoubleLinerNoise_Thickness.onValueChanged.AddListener(this.InputChange_DoubleLinerNoise_Thickness);
        slider_DoubleLinerNoise_SingleOffset.onValueChanged.AddListener(this.SliderChange_DoubleLinerNoise_SingleOffset);
        inputfield_DoubleLinerNoise_SingleOffset.onValueChanged.AddListener(this.InputChange_DoubleLinerNoise_SingleOffset);
        slider_DoubleLinerNoise_SingleRot.onValueChanged.AddListener(this.SliderChange_DoubleLinerNoise_SingleRot);
        inputfield_DoubleLinerNoise_SingleRot.onValueChanged.AddListener(this.InputChange_DoubleLinerNoise_SingleRot);
        slider_DoubleLinerNoise_DoubleRot.onValueChanged.AddListener(this.SliderChange_DoubleLinerNoise_DoubleRot);
        inputfield_DoubleLinerNoise_DoubleRot.onValueChanged.AddListener(this.InputChange_DoubleLinerNoise_DoubleRot);
        slider_DoubleLinerNoise_RandomSeed.onValueChanged.AddListener(this.SliderChange_DoubleLinerNoise_RandomSeed);
        inputfield_DoubleLinerNoise_RandomSeed.onValueChanged.AddListener(this.InputChange_DoubleLinerNoise_RandomSeed);

        //DumbbellNoise特性参数
        slider_DumbbellNoise_GrayCut.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_GrayCut);
        inputfield_DumbbellNoise_GrayCut.onValueChanged.AddListener(this.InputChange_DumbbellNoise_GrayCut);
        slider_DumbbellNoise_BrightnessCut.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_BrightnessCut);
        inputfield_DumbbellNoise_BrightnessCut.onValueChanged.AddListener(this.InputChange_DumbbellNoise_BrightnessCut);
        slider_DumbbellNoise_SideSize_1.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_SideSize_1);
        inputfield_DumbbellNoise_SideSize_1.onValueChanged.AddListener(this.InputChange_DumbbellNoise_SideSize_1);
        slider_DumbbellNoise_SideSize_2.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_SideSize_2);
        inputfield_DumbbellNoise_SideSize_2.onValueChanged.AddListener(this.InputChange_DumbbellNoise_SideSize_2);
        slider_DumbbellNoise_GraphicsDislocation_1.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_GraphicsDislocation_1);
        inputfield_DumbbellNoise_GraphicsDislocation_1.onValueChanged.AddListener(this.InputChange_DumbbellNoise_GraphicsDislocation_1);
        slider_DumbbellNoise_GraphicsDislocation_2.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_GraphicsDislocation_2);
        inputfield_DumbbellNoise_GraphicsDislocation_2.onValueChanged.AddListener(this.InputChange_DumbbellNoise_GraphicsDislocation_2);
        slider_DumbbellNoise_Direction.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_Direction);
        inputfield_DumbbellNoise_Direction.onValueChanged.AddListener(this.InputChange_DumbbellNoise_Direction);
        slider_DumbbellNoise_RandomSeed.onValueChanged.AddListener(this.SliderChange_DumbbellNoise_RandomSeed);
        inputfield_DumbbellNoise_RandomSeed.onValueChanged.AddListener(this.InputChange_DumbbellNoise_RandomSeed);
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

    //DoubleLinerNoise特性参数
    void InputChange_DoubleLinerNoise_Thickness(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DoubleLinerNoise_Thickness.maxValue)
        {
            slider_DoubleLinerNoise_Thickness.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DoubleLinerNoise_Thickness.maxValue)
        {
            slider_DoubleLinerNoise_Thickness.maxValue = float.Parse(va);
            slider_DoubleLinerNoise_Thickness.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DoubleLinerNoise_Thickness.minValue)
        {
            slider_DoubleLinerNoise_Thickness.minValue = float.Parse(va);
            slider_DoubleLinerNoise_Thickness.value = float.Parse(va);
        }
    }
    void InputChange_DoubleLinerNoise_SingleOffset(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DoubleLinerNoise_SingleOffset.maxValue)
        {
            slider_DoubleLinerNoise_SingleOffset.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DoubleLinerNoise_SingleOffset.maxValue)
        {
            slider_DoubleLinerNoise_SingleOffset.maxValue = float.Parse(va);
            slider_DoubleLinerNoise_SingleOffset.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DoubleLinerNoise_SingleOffset.minValue)
        {
            slider_DoubleLinerNoise_SingleOffset.minValue = float.Parse(va);
            slider_DoubleLinerNoise_SingleOffset.value = float.Parse(va);
        }
    }
    void InputChange_DoubleLinerNoise_SingleRot(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DoubleLinerNoise_SingleRot.maxValue)
        {
            slider_DoubleLinerNoise_SingleRot.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DoubleLinerNoise_SingleRot.maxValue)
        {
            slider_DoubleLinerNoise_SingleRot.maxValue = float.Parse(va);
            slider_DoubleLinerNoise_SingleRot.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DoubleLinerNoise_SingleRot.minValue)
        {
            slider_DoubleLinerNoise_SingleRot.minValue = float.Parse(va);
            slider_DoubleLinerNoise_SingleRot.value = float.Parse(va);
        }
    }
    void InputChange_DoubleLinerNoise_DoubleRot(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DoubleLinerNoise_DoubleRot.maxValue)
        {
            slider_DoubleLinerNoise_DoubleRot.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DoubleLinerNoise_DoubleRot.maxValue)
        {
            slider_DoubleLinerNoise_DoubleRot.maxValue = float.Parse(va);
            slider_DoubleLinerNoise_DoubleRot.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DoubleLinerNoise_DoubleRot.minValue)
        {
            slider_DoubleLinerNoise_DoubleRot.minValue = float.Parse(va);
            slider_DoubleLinerNoise_DoubleRot.value = float.Parse(va);
        }
    }
    void InputChange_DoubleLinerNoise_RandomSeed(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DoubleLinerNoise_RandomSeed.maxValue)
        {
            slider_DoubleLinerNoise_RandomSeed.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DoubleLinerNoise_RandomSeed.maxValue)
        {
            slider_DoubleLinerNoise_RandomSeed.maxValue = float.Parse(va);
            slider_DoubleLinerNoise_RandomSeed.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DoubleLinerNoise_RandomSeed.minValue)
        {
            slider_DoubleLinerNoise_RandomSeed.minValue = float.Parse(va);
            slider_DoubleLinerNoise_RandomSeed.value = float.Parse(va);
        }
    }

    void SliderChange_DoubleLinerNoise_Thickness(float value)
    {
        inputfield_DoubleLinerNoise_Thickness.text = slider_DoubleLinerNoise_Thickness.value.ToString();
    }
    void SliderChange_DoubleLinerNoise_SingleOffset(float value)
    {
        inputfield_DoubleLinerNoise_SingleOffset.text = slider_DoubleLinerNoise_SingleOffset.value.ToString();
    }
    void SliderChange_DoubleLinerNoise_SingleRot(float value)
    {
        inputfield_DoubleLinerNoise_SingleRot.text = slider_DoubleLinerNoise_SingleRot.value.ToString();
    }
    void SliderChange_DoubleLinerNoise_DoubleRot(float value)
    {
        inputfield_DoubleLinerNoise_DoubleRot.text = slider_DoubleLinerNoise_DoubleRot.value.ToString();
    }
    void SliderChange_DoubleLinerNoise_RandomSeed(float value)
    {
        inputfield_DoubleLinerNoise_RandomSeed.text = slider_DoubleLinerNoise_RandomSeed.value.ToString();
    }

    //DumbbellNoise特性参数
    void InputChange_DumbbellNoise_GrayCut(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_GrayCut.maxValue)
        {
            slider_DumbbellNoise_GrayCut.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_GrayCut.maxValue)
        {
            slider_DumbbellNoise_GrayCut.maxValue = float.Parse(va);
            slider_DumbbellNoise_GrayCut.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_GrayCut.minValue)
        {
            slider_DumbbellNoise_GrayCut.minValue = float.Parse(va);
            slider_DumbbellNoise_GrayCut.value = float.Parse(va);
        }
    }
    void InputChange_DumbbellNoise_BrightnessCut(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_BrightnessCut.maxValue)
        {
            slider_DumbbellNoise_BrightnessCut.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_BrightnessCut.maxValue)
        {
            slider_DumbbellNoise_BrightnessCut.maxValue = float.Parse(va);
            slider_DumbbellNoise_BrightnessCut.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_BrightnessCut.minValue)
        {
            slider_DumbbellNoise_BrightnessCut.minValue = float.Parse(va);
            slider_DumbbellNoise_BrightnessCut.value = float.Parse(va);
        }
    }
    void InputChange_DumbbellNoise_SideSize_1(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_SideSize_1.maxValue)
        {
            slider_DumbbellNoise_SideSize_1.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_SideSize_1.maxValue)
        {
            slider_DumbbellNoise_SideSize_1.maxValue = float.Parse(va);
            slider_DumbbellNoise_SideSize_1.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_SideSize_1.minValue)
        {
            slider_DumbbellNoise_SideSize_1.minValue = float.Parse(va);
            slider_DumbbellNoise_SideSize_1.value = float.Parse(va);
        }
    }
    void InputChange_DumbbellNoise_SideSize_2(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_SideSize_2.maxValue)
        {
            slider_DumbbellNoise_SideSize_2.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_SideSize_2.maxValue)
        {
            slider_DumbbellNoise_SideSize_2.maxValue = float.Parse(va);
            slider_DumbbellNoise_SideSize_2.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_SideSize_2.minValue)
        {
            slider_DumbbellNoise_SideSize_2.minValue = float.Parse(va);
            slider_DumbbellNoise_SideSize_2.value = float.Parse(va);
        }
    }
    void InputChange_DumbbellNoise_GraphicsDislocation_1(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_GraphicsDislocation_1.maxValue)
        {
            slider_DumbbellNoise_GraphicsDislocation_1.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_GraphicsDislocation_1.maxValue)
        {
            slider_DumbbellNoise_GraphicsDislocation_1.maxValue = float.Parse(va);
            slider_DumbbellNoise_GraphicsDislocation_1.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_GraphicsDislocation_1.minValue)
        {
            slider_DumbbellNoise_GraphicsDislocation_1.minValue = float.Parse(va);
            slider_DumbbellNoise_GraphicsDislocation_1.value = float.Parse(va);
        }
    }
    void InputChange_DumbbellNoise_GraphicsDislocation_2(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_GraphicsDislocation_2.maxValue)
        {
            slider_DumbbellNoise_GraphicsDislocation_2.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_GraphicsDislocation_2.maxValue)
        {
            slider_DumbbellNoise_GraphicsDislocation_2.maxValue = float.Parse(va);
            slider_DumbbellNoise_GraphicsDislocation_2.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_GraphicsDislocation_2.minValue)
        {
            slider_DumbbellNoise_GraphicsDislocation_2.minValue = float.Parse(va);
            slider_DumbbellNoise_GraphicsDislocation_2.value = float.Parse(va);
        }
    }
    void InputChange_DumbbellNoise_Direction(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_Direction.maxValue)
        {
            slider_DumbbellNoise_Direction.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_Direction.maxValue)
        {
            slider_DumbbellNoise_Direction.maxValue = float.Parse(va);
            slider_DumbbellNoise_Direction.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_Direction.minValue)
        {
            slider_DumbbellNoise_Direction.minValue = float.Parse(va);
            slider_DumbbellNoise_Direction.value = float.Parse(va);
        }
    }
    void InputChange_DumbbellNoise_RandomSeed(string va)
    {
        if (float.Parse(va) >= 0 && float.Parse(va) <= slider_DumbbellNoise_RandomSeed.maxValue)
        {
            slider_DumbbellNoise_RandomSeed.value = float.Parse(va);
        }
        if (float.Parse(va) > slider_DumbbellNoise_RandomSeed.maxValue)
        {
            slider_DumbbellNoise_RandomSeed.maxValue = float.Parse(va);
            slider_DumbbellNoise_RandomSeed.value = float.Parse(va);
        }
        if (float.Parse(va) < slider_DumbbellNoise_RandomSeed.minValue)
        {
            slider_DumbbellNoise_RandomSeed.minValue = float.Parse(va);
            slider_DumbbellNoise_RandomSeed.value = float.Parse(va);
        }
    }

    void SliderChange_DumbbellNoise_GrayCut(float value)
    {
        inputfield_DumbbellNoise_GrayCut.text = slider_DumbbellNoise_GrayCut.value.ToString();
    }
    void SliderChange_DumbbellNoise_BrightnessCut(float value)
    {
        inputfield_DumbbellNoise_BrightnessCut.text = slider_DumbbellNoise_BrightnessCut.value.ToString();
    }
    void SliderChange_DumbbellNoise_SideSize_1(float value)
    {
        inputfield_DumbbellNoise_SideSize_1.text = slider_DumbbellNoise_SideSize_1.value.ToString();
    }
    void SliderChange_DumbbellNoise_SideSize_2(float value)
    {
        inputfield_DumbbellNoise_SideSize_2.text = slider_DumbbellNoise_SideSize_2.value.ToString();
    }
    void SliderChange_DumbbellNoise_GraphicsDislocation_1(float value)
    {
        inputfield_DumbbellNoise_GraphicsDislocation_1.text = slider_DumbbellNoise_GraphicsDislocation_1.value.ToString();
    }
    void SliderChange_DumbbellNoise_GraphicsDislocation_2(float value)
    {
        inputfield_DumbbellNoise_GraphicsDislocation_2.text = slider_DumbbellNoise_GraphicsDislocation_2.value.ToString();
    }
    void SliderChange_DumbbellNoise_Direction(float value)
    {
        inputfield_DumbbellNoise_Direction.text = slider_DumbbellNoise_Direction.value.ToString();
    }
    void SliderChange_DumbbellNoise_RandomSeed(float value)
    {
        inputfield_DumbbellNoise_RandomSeed.text = slider_DumbbellNoise_RandomSeed.value.ToString();
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
        if (choseNoiseName == 8)
        {
            canvas_Common.enabled = true;
            canvas_PeriodNoise.enabled = false;
            canvas_VoroNoise.enabled = false;
            canvas_SmokeNoise.enabled = false;
            canvas_WorleyNoise.enabled = false;
            canvas_DowntownNoise.enabled = false;
            canvas_DoubleLinerNoise.enabled = true;
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

            float doubleLinerNoise_Thickness = slider_DoubleLinerNoise_Thickness.value;
            material.SetFloat("_DoubleLinerNoise_Thickness", doubleLinerNoise_Thickness);

            float doubleLinerNoise_SingleOffset = slider_DoubleLinerNoise_SingleOffset.value;
            material.SetFloat("_DoubleLinerNoise_SingleOffset", doubleLinerNoise_SingleOffset);

            float doubleLinerNoise_SingleRot = slider_DoubleLinerNoise_SingleRot.value;
            material.SetFloat("_DoubleLinerNoise_SingleRot", doubleLinerNoise_SingleRot);

            float doubleLinerNoise_DoubleRot = slider_DoubleLinerNoise_DoubleRot.value;
            material.SetFloat("_DoubleLinerNoise_DoubleRot", doubleLinerNoise_DoubleRot);

            float doubleLinerNoise_RandomSeed = slider_DoubleLinerNoise_RandomSeed.value;
            material.SetFloat("_DoubleLinerNoise_RandomSeed", doubleLinerNoise_RandomSeed);
        }
        if (choseNoiseName == 9)
        {
            canvas_Common.enabled = true;
            canvas_PeriodNoise.enabled = false;
            canvas_VoroNoise.enabled = false;
            canvas_SmokeNoise.enabled = false;
            canvas_WorleyNoise.enabled = false;
            canvas_DowntownNoise.enabled = false;
            canvas_DoubleLinerNoise.enabled = false;
            canvas_DumbbellNoise.enabled = true;
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

            float dumbbellNoise_GrayCut = slider_DumbbellNoise_GrayCut.value;
            material.SetFloat("_DumbbellNoise_GrayCut", dumbbellNoise_GrayCut);

            float dumbbellNoise_BrightnessCut = slider_DumbbellNoise_BrightnessCut.value;
            material.SetFloat("_DumbbellNoise_BrightnessCut", dumbbellNoise_BrightnessCut);

            float dumbbellNoise_SideSize_1 = slider_DumbbellNoise_SideSize_1.value;
            material.SetFloat("_DumbbellNoise_SideSize_1", dumbbellNoise_SideSize_1);

            float dumbbellNoise_SideSize_2 = slider_DumbbellNoise_SideSize_2.value;
            material.SetFloat("_DumbbellNoise_SideSize_2", dumbbellNoise_SideSize_2);

            float dumbbellNoise_GraphicsDislocation_1 = slider_DumbbellNoise_GraphicsDislocation_1.value;
            material.SetFloat("_DumbbellNoise_GraphicsDislocation_1", dumbbellNoise_GraphicsDislocation_1);

            float dumbbellNoise_GraphicsDislocation_2 = slider_DumbbellNoise_GraphicsDislocation_2.value;
            material.SetFloat("_DumbbellNoise_GraphicsDislocation_2", dumbbellNoise_GraphicsDislocation_2);

            float dumbbellNoise_Direction = slider_DumbbellNoise_Direction.value;
            material.SetFloat("_DumbbellNoise_Direction", dumbbellNoise_Direction);

            float dumbbellNoise_RandomSeed = slider_DumbbellNoise_RandomSeed.value;
            material.SetFloat("_DumbbellNoise_RandomSeed", dumbbellNoise_RandomSeed);
        }
    }
}
