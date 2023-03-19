
using UnityEngine;
using ColorUiTools;
using UnityEngine.UI;

public class ColorNoiseMaterialColorPicker : MonoBehaviour
{
    /// <summary>
    /// 颜色选择器
    /// </summary>
    public ColorPicker colorPicker_1 = null;
    public ColorPicker colorPicker_2 = null;

    public Toggle isTimeRun;

    public Material colorMaterial;

    private float timeRun;
    public InputField inputField_TimeSpeed;

    public int timeScale_In = 1;

    private void Awake()
    {
        colorPicker_1.onPicker.AddListener(color_1 =>
        {
            
            colorMaterial.SetColor("_MainColor_1", color_1);
        });
        colorPicker_2.onPicker.AddListener(color_2 =>
        {
            
            colorMaterial.SetColor("_MainColor_2", color_2);
        });
    }

    void Update()
    {
        if (isTimeRun.isOn == true)
        {
            timeRun = Time.time * float.Parse(inputField_TimeSpeed.text);
            colorMaterial.SetFloat("_TimeRun", timeRun);
        }
        if (isTimeRun == false)
        {
            timeRun = 0;
            colorMaterial.SetFloat("_TimeRun", timeRun);
        }
    }
}