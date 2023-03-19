using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NoiseCreater
{
    public class SaveRenderTexture : MonoBehaviour
    //public class SaveRenderTexture : OnePointTwoNoCreak_Material
    {

        //public RenderTexture target;
        private RenderTexture rt;
        //public RenderTexture rt0;
        //public InputField inputfield_NoiseRenderTextureSize;
        //public Button trueButton;

        int index = 0;

        public InputField inputField = null;
        
        private void Start()
        {
            GameObject.Find("SaveBtn").GetComponent<Button>().onClick.AddListener(() =>
            {
                OnUserSave();
            });

            //int NRTS = int.Parse(inputfield_NoiseRenderTextureSize.text);
            //rt = new RenderTexture(NRTS, NRTS, 0);
            //Camera cam = Camera.main;
            //cam.targetTexture = rt;

        }

        //public void ClickButton()
        //{
        //    int NRTS = int.Parse(inputfield_NoiseRenderTextureSize.text);
        //    rt = new RenderTexture(NRTS, NRTS, 0);
        //    Camera cam = Camera.main;
        //    cam.targetTexture = rt;
        //}

        //void Update()
        //{
        //    Camera.main.targetTexture = rt;
        //}

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
            rt = Camera.main.targetTexture;
            
            Save(path, CreateFrom(rt));
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
            var previous = RenderTexture.active;
            RenderTexture.active = renderTexture;

            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);

            RenderTexture.active = previous;

            texture2D.Apply();

            return texture2D;
        }


    }
}