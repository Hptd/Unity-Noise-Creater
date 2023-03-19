using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.IO;

public class InputTextureToMaterialWithMath : MonoBehaviour
{
    public Material material;
    public Slider mixPowerSet;
    public Dropdown mathChose;
    public Toggle isUsing;
    private int toggleIsUsing;

    RawImage img;
    public void SetTextureByFile()
    {
        img = transform.GetComponent<RawImage>();
        OpenFileName ofn = new OpenFileName();
        ofn.structSize = Marshal.SizeOf(ofn);
        ofn.filter = "All Files\0*.*\0\0";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        string path = Application.streamingAssetsPath;
        path = path.Replace('/', '\\');
        ofn.initialDir = path;
        ofn.title = "Open Project";
        ofn.defExt = "JPG";
        //注意 一下项目不一定要全选 但是0x00000008项不要缺少  
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR  

        //外部加载图片进材质球
        if (WindowDll.GetOpenFileName(ofn))
        {
            Texture2D inputTex = LoadTexture(ofn.file);
            material.SetTexture("_MainTex", inputTex);
            //Debug.Log("Selected file with full path: {0}" + ofn.file);
        }
    }

    void Update()
    {
        if (isUsing.isOn == false)
        {
            toggleIsUsing = 0;
            material.SetFloat("_IsUsingTexture", toggleIsUsing);
        }
        if (isUsing.isOn == true)
        {
            toggleIsUsing = 1;
            material.SetFloat("_IsUsingTexture", toggleIsUsing);
            material.SetFloat("_MixPowerSet", mixPowerSet.value);
            material.SetFloat("_MathChose", mathChose.value);
        }
    }

    public Texture2D LoadTexture(string path)
    {
        Texture2D tex = new Texture2D(1, 1);
        tex.LoadImage(File.ReadAllBytes(path));
        return tex;
    }

    //IEnumerator GetTexture(string path, Action<Texture> callback)
    //{
    //    UnityWebRequest uwr = new UnityWebRequest(path);
    //    DownloadHandlerTexture dht = new DownloadHandlerTexture(true);
    //    uwr.downloadHandler = dht;
    //    yield return uwr.SendWebRequest();
    //    if (!uwr.isNetworkError)
    //    {
    //        callback(dht.texture);
    //    }
    //}
}

