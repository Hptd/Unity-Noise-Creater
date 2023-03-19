using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class ResetValueButton : MonoBehaviour
    {
        public InputField inputField_Common_Size;
        public InputField inputField_Common_Contrast;
        public InputField inputField_Common_Brightness;
        public InputField inputField_Common_X_Move;
        public InputField inputField_Common_Y_Move;
        public InputField inputField_Common_X_Size;
        public InputField inputField_Common_Y_Size;

        public InputField inputField_Common_Y_NoCreakGrident;
        public InputField inputField_Common_Y_NoCreakSize;
        public InputField inputField_Common_X_NoCreakGrident;
        public InputField inputField_Common_X_NoCreakSize;
        //周期噪波数值
        public InputField inputField_Period_Period;
        public InputField inputField_Period_BreakSize;
        //VoroNoise
        public InputField inputField_VoroNoise_FormOffsect;
        public InputField inputField_VoroNoise_Blur;
        public InputField inputField_VoroNoise_Form; 
        public InputField inputField_VoroNoise_FakeHeight;
        public InputField inputField_VoroNoise_RandomSeed;
        //SmokeNoise
        public InputField inputField_SmokeNoise_FormOffsect;
        public InputField inputField_SmokeNoise_Curvature;
        public InputField inputField_SmokeNoise_Level;
        public InputField inputField_SmokeNoise_Particle;
        public InputField inputField_SmokeNoise_MoveLevel;
        public InputField inputField_SmokeNoise_RandomSeed;

        //WorleyNoise
        public InputField inputField_WorleyNoise_FormOffsect;
        public InputField inputField_WorleyNoise_RandomSeed;

        //DowntownNoise
        public InputField inputfield_DowntownNoise_Level;
        public InputField inputfield_DowntownNoise_LevelBreakSize;
        public InputField inputfield_DowntownNoise_LayersMove;
        public InputField inputfield_DowntownNoise_RandomSeed;

        //DoubleLinerNoise
        public InputField inputfield_DoubleLinerNoise_Thickness;
        public InputField inputfield_DoubleLinerNoise_SingleOffset;
        public InputField inputfield_DoubleLinerNoise_SingleRot;
        public InputField inputfield_DoubleLinerNoise_DoubleRot;
        public InputField inputfield_DoubleLinerNoise_RandomSeed;

        //DumbbellNoise
        public InputField inputfield_DumbbellNoise_GrayCut;
        public InputField inputfield_DumbbellNoise_BrightnessCut;
        public InputField inputfield_DumbbellNoise_SideSize_1;
        public InputField inputfield_DumbbellNoise_SideSize_2;
        public InputField inputfield_DumbbellNoise_GraphicsDislocation_1;
        public InputField inputfield_DumbbellNoise_GraphicsDislocation_2;
        public InputField inputfield_DumbbellNoise_Direction;
        public InputField inputfield_DumbbellNoise_RandomSeed;

        //StepNoise
        public InputField inputfield_StepNoise_Boundary_1;
        public InputField inputfield_StepNoise_Boundary_2;
        public InputField inputfield_StepNoise_Boundary_3;

        //BrickNoise
        public InputField inputfield_BrickNoise_CrackOffset;
        public InputField inputfield_BrickNoise_X_CrackWidth;
        public InputField inputfield_BrickNoise_Y_CrackWidth;

        //WaveletNoise
        public InputField inputfield_WaveletNoise_Noiselayer;
        public InputField inputfield_WaveletNoise_SharpPower;
        public InputField inputfield_WaveletNoise_FormChange;
        public InputField inputfield_WaveletNoise_RandomSeed;
        //------------------------------------------------------------------------------------//

        public void OnInputField_Common_Size()
        {
            inputField_Common_Size.text = (20).ToString();
        }
        public void OnInputField_Common_Contrast()
        {
            inputField_Common_Contrast.text = (0.43).ToString();
        }
        public void OnInputField_Common_Brightness()
        {
            inputField_Common_Brightness.text = (0.5).ToString();
        }
        public void OnInputField_Common_X_Move()
        {
            inputField_Common_X_Move.text = (0.5).ToString();
        }
        public void OnInputField_Common_Y_Move()
        {
            inputField_Common_Y_Move.text = (0.5).ToString();
        }
        public void OnInputField_Common_X_Size()
        {
            inputField_Common_X_Size.text = (0).ToString();
        }
        public void OnInputField_Common_Y_Size()
        {
            inputField_Common_Y_Size.text = (0).ToString();
        }
        //NoCreak
        public void OnInputField_Common_Y_NoCreakGrident()
        {
            inputField_Common_Y_NoCreakGrident.text = (0).ToString();
        }
        public void OnInputField_Common_Y_NoCreakSize()
        {
            inputField_Common_Y_NoCreakSize.text = (1).ToString();
        }
        public void OnInputField_Common_X_NoCreakGrident()
        {
            inputField_Common_X_NoCreakGrident.text = (0).ToString();
        }
        public void OnInputField_Common_X_NoCreakSize()
        {
            inputField_Common_X_NoCreakSize.text = (1).ToString();
        }
        //周期噪波
        public void OnInputField_Period_Period()
        {
            inputField_Period_Period.text = (0.5).ToString();
        }
        public void OnInputField_Period_BreakSize()
        {
            inputField_Period_BreakSize.text = (0.6).ToString();
        }
        //VoroNoise
        public void OnInputField_VoroNoise_FormOffsect()
        {
            inputField_VoroNoise_FormOffsect.text = (0.3).ToString();
        }
        public void OnInputField_VoroNoise_Blur()
        {
            inputField_VoroNoise_Blur.text = (1).ToString();
        }
        public void OnInputField_VoroNoise_Form()
        {
            inputField_VoroNoise_Form.text = (0.0707).ToString();
        }
        public void OnInputField_VoroNoise_FakeHeight()
        {
            inputField_VoroNoise_FakeHeight.text = (1).ToString();
        }
        public void OnInputField_VoroNoise_RandomSeed()
        {
            inputField_VoroNoise_RandomSeed.text = (0.5).ToString();
        }
        //SmokeNoise
        public void OnInputField_SmokeNoise_FormOffsect()
        {
            inputField_SmokeNoise_FormOffsect.text = (0).ToString();
        }
        public void OnInputField_SmokeNoise_Curvature()
        {
            inputField_SmokeNoise_Curvature.text = (0.16667).ToString();
        }
        public void OnInputField_SmokeNoise_Level()
        {
            inputField_SmokeNoise_Level.text = (0.35).ToString();
        }
        public void OnInputField_SmokeNoise_Particle()
        {
            inputField_SmokeNoise_Particle.text = (0.05).ToString();
        }
        public void OnInputField_SmokeNoise_MoveLevel()
        {
            inputField_SmokeNoise_MoveLevel.text = (0.03).ToString();
        }
        public void OnInputField_SmokeNoise_RandomSeed()
        {
            inputField_SmokeNoise_RandomSeed.text = (0).ToString();
        }
        //WorleyNoise
        public void OnInputField_WorleyNoise_FormOffsect()
        {
            inputField_WorleyNoise_FormOffsect.text = (1).ToString();
        }
        public void OnInputField_WorleyNoise_RandomSeed()
        {
            inputField_WorleyNoise_RandomSeed.text = (0).ToString();
        }
        //DowntownNoise
        public void OnInputField_DowntownNoise_Level()
        {
            inputfield_DowntownNoise_Level.text = (1).ToString();
        }
        public void OnInputField_DowntownNoise_LevelBreakSize()
        {
            inputfield_DowntownNoise_LevelBreakSize.text = (0.1).ToString();
        }
        public void OnInputField_DowntownNoise_LayersMove()
        {
            inputfield_DowntownNoise_LayersMove.text = (0.025).ToString();
        }
        public void OnInputField_DowntownNoise_RandomSeed()
        {
            inputfield_DowntownNoise_RandomSeed.text = (0).ToString();
        }
        //DoubleLinerNoise
        public void OnInputField_DoubleLinerNoise_Thickness()
        {
            inputfield_DoubleLinerNoise_Thickness.text = (0.15).ToString();
        }
        public void OnInputField_DoubleLinerNoise_SingleOffset()
        {
            inputfield_DoubleLinerNoise_SingleOffset.text = (0.5).ToString();
        }
        public void OnInputField_DoubleLinerNoise_SingleRot()
        {
            inputfield_DoubleLinerNoise_SingleRot.text = (0.49866).ToString();
        }
        public void OnInputField_DoubleLinerNoise_DoubleRot()
        {
            inputfield_DoubleLinerNoise_DoubleRot.text = (0).ToString();
        }
        public void OnInputField_DoubleLinerNoise_RandomSeed()
        {
            inputfield_DoubleLinerNoise_RandomSeed.text = (0).ToString();
        }
        //DumbbellNoise
        public void OnInputField_DumbbellNoise_GrayCut()
        {
            inputfield_DumbbellNoise_GrayCut.text = (0.00142857).ToString();
        }
        public void OnInputField_DumbbellNoise_BrightnessCut()
        {
            inputfield_DumbbellNoise_BrightnessCut.text = (0.5).ToString();
        }
        public void OnInputField_DumbbellNoise_SideSize_1()
        {
            inputfield_DumbbellNoise_SideSize_1.text = (0.08).ToString();
        }
        public void OnInputField_DumbbellNoise_SideSize_2()
        {
            inputfield_DumbbellNoise_SideSize_2.text = (0.08).ToString();
        }
        public void OnInputField_DumbbellNoise_GraphicsDislocation_1()
        {
            inputfield_DumbbellNoise_GraphicsDislocation_1.text = (0.375).ToString();
        }
        public void OnInputField_DumbbellNoise_GraphicsDislocation_2()
        {
            inputfield_DumbbellNoise_GraphicsDislocation_2.text = (0.375).ToString();
        }
        public void OnInputField_DumbbellNoise_Direction()
        {
            inputfield_DumbbellNoise_Direction.text = (0.5).ToString();
        }
        public void OnInputField_DumbbellNoise_RandomSeed()
        {
            inputfield_DumbbellNoise_RandomSeed.text = (1).ToString();
        }
        //StepNoise
        public void OnInputField_StepNoise_Boundary_1()
        {
            inputfield_StepNoise_Boundary_1.text = (0.2).ToString();
        }
        public void OnInputField_StepNoise_Boundary_2()
        {
            inputfield_StepNoise_Boundary_2.text = (0.85).ToString();
        }
        public void OnInputField_StepNoise_Boundary_3()
        {
            inputfield_StepNoise_Boundary_3.text = (1).ToString();
        }
        //BrickNoise
        public void OnInputField_BrickNoise_CrackOffset()
        {
            inputfield_BrickNoise_CrackOffset.text = (0.479).ToString();
        }
        public void OnInputField_BrickNoise_X_CrackWidth()
        {
            inputfield_BrickNoise_X_CrackWidth.text = (0.01).ToString();
        }
        public void OnInputField_BrickNoise_Y_CrackWidth()
        {
            inputfield_BrickNoise_Y_CrackWidth.text = (0.1).ToString();
        }
        //WaveletNoise
        public void OnInputField_WaveletNoise_NoiseLayer()
        {
            inputfield_WaveletNoise_Noiselayer.text = (0.25).ToString();
        }
        public void OnInputField_WaveletNoise_SharpPower()
        {
            inputfield_WaveletNoise_SharpPower.text = (0.25).ToString();
        }
        public void OnInputField_WaveletNoise_FormChange()
        {
            inputfield_WaveletNoise_FormChange.text = (0).ToString();
        }
        public void OnInputField_WaveletNoise_RandomSeed()
        {
            inputfield_WaveletNoise_RandomSeed.text = (0).ToString();
        }
    }
}
