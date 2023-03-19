using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace NoiseCreater
{
    public class OpenFileTest : MonoBehaviour
    {

        public InputField inputField = null;

        /// <summary>
        /// 浏览按钮
        /// </summary>
        public UnityEngine.UI.Button browseBtn;

        private void Awake()
        {
            browseBtn.onClick.AddListener(OnClickLiuLanBtn);
        }

        /// <summary>
        /// 点击了浏览按钮
        /// </summary>
        public void OnClickLiuLanBtn()
        //public string OnClickLiuLanBtn()
        {
            OpenFileName openFileName = new OpenFileName();

            openFileName.structSize = Marshal.SizeOf(openFileName);

            //控制指定文件的后缀名格式
            openFileName.filter = "PNG文件(*.PNG)\0*.PNG";

            openFileName.file = new string(new char[256]);

            string fileName = openFileName.file;

            openFileName.maxFile = openFileName.file.Length;

            openFileName.fileTitle = new string(new char[64]);

            openFileName.maxFileTitle = openFileName.fileTitle.Length;

            openFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//默认路径

            openFileName.title = "新窗口名称";

            openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

            //if (LocalDialog.GetOpenFileName(openFileName))
            //{ 
            //    inputField.text = openFileName.file;
            //}

            if (LocalDialog.GetSaveFileName(openFileName))
            {
                inputField.text = openFileName.file;
            }

            //if (LocalDialog.GetOpenFileName(openFileName))
            //{
            //Debug.Log(openFileName.file);
            //Debug.Log(openFileName.fileTitle);

            //}
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class OpenFileName
    {
        public int structSize = 0;

        public IntPtr dlgOwner = IntPtr.Zero;

        public IntPtr instance = IntPtr.Zero;

        public String filter = null;

        public String customFilter = null;

        public int maxCustFilter = 0;

        public int filterIndex = 0;

        public String file = null;

        public int maxFile = 0;

        public String fileTitle = null;

        public int maxFileTitle = 0;

        public String initialDir = null;

        public String title = null;

        public int flags = 0;

        public short fileOffset = 0;

        public short fileExtension = 0;

        public String defExt = null;

        public IntPtr custData = IntPtr.Zero;

        public IntPtr hook = IntPtr.Zero;

        public String templateName = null;

        public IntPtr reservedPtr = IntPtr.Zero;

        public int reservedInt = 0;

        public int flagsEx = 0;

    }

    public class LocalDialog
    {

        //链接指定系统函数       打开文件对话框
        //[DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]

        //public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
        //public static bool GetOFN([In, Out] OpenFileName ofn)
        //{
        //    return GetOpenFileName(ofn);
        //}

        //链接指定系统函数        另存为对话框
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]

        public static extern bool GetSaveFileName([In, Out] OpenFileName ofn);
        public static bool GetSFN([In, Out] OpenFileName ofn)
        {
            return GetSaveFileName(ofn);
        }
    }
}
