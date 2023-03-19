using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NoiseCreater
{
    public class SaveRenderTextureAndNoCreak : MonoBehaviour
    {
        private RenderTexture rt;

        int index = 0;

        public InputField inputField = null;

        //无缝处理
        public Camera cameraZhongzhuan;
        public Camera noise0Camera;
        public Camera mainCamera;

        public Material material_Y;
        public Material material_X;

        public Slider crackWeight;
        public InputField inputfield_crackWeight;
        public Slider crackGrdient;
        public InputField inputfield_crackGrdient;

        public Slider crackWeight_X;
        public InputField inputfield_crackWeight_X;
        public Slider crackGrdient_X;
        public InputField inputfield_crackGrdient_X;

        private RenderTexture Noise0;
        public InputField inputfield_NoiseRenderTextureSize;
        public Button trueButton;

        private void Start()
        {
            GameObject.Find("SaveBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                OnUserSave();
            });

            int NRTS = int.Parse(inputfield_NoiseRenderTextureSize.text);
            Noise0 = new RenderTexture(NRTS, NRTS, 0);
            Noise0.wrapMode = TextureWrapMode.Repeat;
            noise0Camera.targetTexture = Noise0;
            cameraZhongzhuan.targetTexture = new RenderTexture(Noise0.width, Noise0.height, 0);
            mainCamera.targetTexture = new RenderTexture(Noise0.width, Noise0.height, 0);
            rt = mainCamera.targetTexture;

            ///////滑动条和输入框双向调整///////
            Initialize(inputfield_crackWeight, crackWeight);
            Initialize(inputfield_crackGrdient, crackGrdient);
            Initialize(inputfield_crackWeight_X, crackWeight_X); 
            Initialize(inputfield_crackGrdient_X, crackGrdient_X);

            crackWeight.onValueChanged.AddListener(this.SliderChange_crackWeight);
            inputfield_crackWeight.onValueChanged.AddListener(this.InputChange_crackWeight);
            crackGrdient.onValueChanged.AddListener(this.SliderChange_crackGrdient);
            inputfield_crackGrdient.onValueChanged.AddListener(this.InputChange_crackGrdient);
            crackWeight_X.onValueChanged.AddListener(this.SliderChange_crackWeight_X);
            inputfield_crackWeight_X.onValueChanged.AddListener(this.InputChange_crackWeight_X);
            crackGrdient_X.onValueChanged.AddListener(this.SliderChange_crackGrdient_X);
            inputfield_crackGrdient_X.onValueChanged.AddListener(this.InputChange_crackGrdient_X);
        }

        ///////滑动条和输入框双向调整///////
        //初始化参数
        void Initialize(InputField inputField, Slider slider)
        {
            inputField.text = slider.value.ToString();
        }

        void SliderChange_crackWeight(float value)
        {
            inputfield_crackWeight.text = crackWeight.value.ToString();
        }
        void SliderChange_crackGrdient(float value)
        {
            inputfield_crackGrdient.text = crackGrdient.value.ToString();
        }
        void SliderChange_crackWeight_X(float value)
        {
            inputfield_crackWeight_X.text = crackWeight_X.value.ToString();
        }
        void SliderChange_crackGrdient_X(float value)
        {
            inputfield_crackGrdient_X.text = crackGrdient_X.value.ToString();
        }

        void InputChange_crackWeight(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= crackWeight.maxValue)
            {
                crackWeight.value = float.Parse(va);
            }
            if (float.Parse(va) > crackWeight.maxValue)
            {
                crackWeight.maxValue = float.Parse(va);
                crackWeight.value = float.Parse(va);
            }
            if (float.Parse(va) < crackWeight.minValue)
            {
                crackWeight.minValue = float.Parse(va);
                crackWeight.value = float.Parse(va);
            }
        }
        void InputChange_crackGrdient(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= crackGrdient.maxValue)
            {
                crackGrdient.value = float.Parse(va);
            }
            if (float.Parse(va) > crackGrdient.maxValue)
            {
                crackGrdient.maxValue = float.Parse(va);
                crackGrdient.value = float.Parse(va);
            }
            if (float.Parse(va) < crackGrdient.minValue)
            {
                crackGrdient.minValue = float.Parse(va);
                crackGrdient.value = float.Parse(va);
            }
        }
        void InputChange_crackWeight_X(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= crackWeight_X.maxValue)
            {
                crackWeight_X.value = float.Parse(va);
            }
            if (float.Parse(va) > crackWeight_X.maxValue)
            {
                crackWeight_X.maxValue = float.Parse(va);
                crackWeight_X.value = float.Parse(va);
            }
            if (float.Parse(va) < crackWeight_X.minValue)
            {
                crackWeight_X.minValue = float.Parse(va);
                crackWeight_X.value = float.Parse(va);
            }
        }
        void InputChange_crackGrdient_X(string va)
        {
            if (float.Parse(va) >= 0 && float.Parse(va) <= crackGrdient_X.maxValue)
            {
                crackGrdient_X.value = float.Parse(va);
            }
            if (float.Parse(va) > crackGrdient_X.maxValue)
            {
                crackGrdient_X.maxValue = float.Parse(va);
                crackGrdient_X.value = float.Parse(va);
            }
            if (float.Parse(va) < crackGrdient_X.minValue)
            {
                crackGrdient_X.minValue = float.Parse(va);
                crackGrdient_X.value = float.Parse(va);
            }
        }




        public void ClickButton()
        {
            int NRTS = int.Parse(inputfield_NoiseRenderTextureSize.text);
            Noise0 = new RenderTexture(NRTS, NRTS, 0);
            Noise0.wrapMode = TextureWrapMode.Repeat;
            noise0Camera.targetTexture = Noise0;
            cameraZhongzhuan.targetTexture = new RenderTexture(Noise0.width, Noise0.height, 0);
            mainCamera.targetTexture = new RenderTexture(Noise0.width,Noise0.height, 0);
            rt = mainCamera.targetTexture;
        }

        void Update()
        {
            
            material_Y.SetTexture("_Y_NoiseResult", noise0Camera.targetTexture);
            material_Y.SetFloat("_CrackWeight", crackWeight.value);
            material_Y.SetFloat("_CrackGrdient", crackGrdient.value);

            material_X.SetTexture("_X_NoiseResult", cameraZhongzhuan.targetTexture);
            material_X.SetFloat("_CrackWeight", crackWeight_X.value);
            material_X.SetFloat("_CrackGrdient", crackGrdient_X.value);
        }

        public void OnUserSave()
        {
            //OpenFileName openFileName = new OpenFileName();

            //var prePath = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf("/"));

            //string path = prePath + string.Format("/SaveFX/EFX{0}.png", index);
            //string path = prePath + string.Format("openFileName.file/T_Noise{0}.png", index);
            string fileName = inputField.text;
            string path = string.Format(fileName, index);

            //Camera.main.targetTexture = RenderTexture.active;

            //RenderTexture.active = rt;
            //rt = Camera.main.targetTexture;

            Save(path, CreateFrom(rt));
            //Save(path, CreateFrom(mainCamera.targetTexture));
            //index++;
        }

        public void Save(string path, Texture2D texture2D)
        {
            //Debug.Log("Save Path:" + path);
            var bytes = texture2D.EncodeToPNG();
            System.IO.File.WriteAllBytes(path, bytes);
        }

        public Texture2D CreateFrom(RenderTexture renderTexture)
        {
            Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            //var previous = RenderTexture.active;
            RenderTexture.active = renderTexture;

            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

            //RenderTexture.active = previous;

            texture2D.Apply();

            return texture2D;
        }


    }
}