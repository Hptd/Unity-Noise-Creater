using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class OnePointTwoNoCreak_Material : MonoBehaviour
    {
        /*此版本代码已作废，仅供后续开发参考使用；
         * 
         * 详情请查看 "SaveRenderTextureAndNoCreak" 脚本代码
         * 
         */

        //无缝处理
        public Camera cameraZhongzhuan;
        public Camera noise0Camera;
        //public Camera mainCamera;

        public Material material_Y;
        public Material material_X;

        public Slider crackWeight;
        public Slider crackGrdient;

        public Slider crackWeight_X;
        public Slider crackGrdient_X;

        //public Shader shader_Y;
        //public Shader shader_X;

        private RenderTexture Noise0;
        private RenderTexture rt0;
        private RenderTexture rt1;
        private RenderTexture rt2;
        private Texture2D zhongZhuanNoise;
        //private Texture2D mainCameraTexture;
        //public Texture2D testTexture;

        public InputField inputfield_NoiseRenderTextureSize;
        public Button trueButton;


        private void Start()
        {
            int NRTS = int.Parse(inputfield_NoiseRenderTextureSize.text);
            Noise0 = new RenderTexture(NRTS, NRTS, 0);
            Noise0.wrapMode = TextureWrapMode.Repeat;
            //Noise0.graphicsFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.R32G32B32A32_UInt;
            noise0Camera.targetTexture = Noise0;

            cameraZhongzhuan.targetTexture = new RenderTexture(Noise0.width, Noise0.height, 0);
            //Camera.main.targetTexture = new RenderTexture(Noise0.width, Noise0.width, 0);
            //rt0 = noise0Camera.targetTexture;

            //zhongZhuanNoise = RenderTextureToTexture2D((RenderTexture)rt0);

            //rt1 = cameraZhongzhuan.targetTexture;
            //mainCameraTexture = RenderTextureToTexture2D((RenderTexture)rt1);

            //beginNoise = RenderTextureToTexture2D((RenderTexture)Noise0);
        }

        public void ClickButton()
        {
            int NRTS = int.Parse(inputfield_NoiseRenderTextureSize.text);
            Noise0 = new RenderTexture(NRTS, NRTS, 0);
            Noise0.wrapMode = TextureWrapMode.Repeat;
            //Noise0.graphicsFormat = UnityEngine.Experimental.Rendering.GraphicsFormat.R32G32B32A32_UInt;
            noise0Camera.targetTexture = Noise0;

            cameraZhongzhuan.targetTexture = new RenderTexture(Noise0.width, Noise0.height, 0);
            //Camera.main.targetTexture = new RenderTexture(Noise0.width, Noise0.width, 0);
        }

        Texture2D RenderTextureToTexture2D(RenderTexture rTex)
        {
            Texture2D dest = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
            dest.Apply(false);
            Graphics.CopyTexture(rTex, dest);
            
            return dest;
        }

        Texture2D RT2T(RenderTexture texture)
        {
            //Texture2D tex = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);
            //RenderTexture.active = texture;
            //tex.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
            //tex.Apply();
            //return tex;

            Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
            Graphics.Blit(texture, renderTexture);

            RenderTexture.active = renderTexture;
            texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture2D.Apply();

            RenderTexture.active = currentRT;
            RenderTexture.ReleaseTemporary(renderTexture);

            return texture2D;
        }

        Texture2D RenderTextureTo2DTexture(RenderTexture rt)
        {
            var texture = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);
            RenderTexture.active = rt;
            texture.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
            texture.Apply();

            //RenderTexture.active = null;

            return texture;
        }

        private Texture2D Gettex2d(RenderTexture rendertex)
        {
            var texture = new Texture2D(rendertex.width, rendertex.height, TextureFormat.ARGB4444, false);
            RenderTexture.active = rendertex;
            texture.ReadPixels(new Rect(0, 0, rendertex.width, rendertex.height), 0, 0);
            //texture.Apply(texture);
            return texture;
        }

        void Update()
        {
            //rt1 = RenderTexture.active;
            //rt0 = RenderTexture.active;

            rt1 = noise0Camera.targetTexture;
            //rt1 = cameraZhongzhuan.targetTexture;

            //zhongZhuanNoise = RenderTextureToTexture2D(rt1);
            //zhongZhuanNoise = RT2T((RenderTexture)rt1);
            //zhongZhuanNoise = Gettex2d(rt1);

            //zhongZhuanNoise = RenderTextureTo2DTexture((RenderTexture)rt1);
            //material_Y.SetTexture("_Y_NoiseResult", zhongZhuanNoise);
            //Texture2D.Destroy(zhongZhuanNoise);
            material_Y.SetTexture("_Y_NoiseResult", rt1);
            //material_Y.SetTexture("_Y_NoiseResult", testTexture);
            material_Y.SetFloat("_CrackWeight", crackWeight.value);
            material_Y.SetFloat("_CrackGrdient", crackGrdient.value);

            
            cameraZhongzhuan.targetTexture = rt1;
            rt2 = cameraZhongzhuan.targetTexture;
            //cameraZhongzhuan.targetTexture.Release();
            //Camera.main.targetTexture = rt2;
            //rt2 = Camera.main.targetTexture;
            //mainCameraTexture = RenderTextureToTexture2D((RenderTexture)rt2);
            //material_X.SetTexture("_X_NoiseResult", mainCameraTexture);
            material_X.SetTexture("_X_NoiseResult", rt2);
            material_X.SetFloat("_CrackWeight", crackWeight_X.value);
            material_X.SetFloat("_CrackGrdient", crackGrdient_X.value);

            //RenderTexture.active = Camera.main.targetTexture;
            //Camera.main.targetTexture = RenderTexture.active;

            //rt00 = Camera.main.targetTexture;
        }

        void FixedUpdate()
        {
            
        }
    }
}
