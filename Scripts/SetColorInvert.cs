using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorInvert : MonoBehaviour
{
    public Material material;

    public Toggle isInvert;
    private int isOnToggle = 0;

    void Update()
    {
        if (isInvert.isOn == false)
        {
            isOnToggle = 0;
            material.SetFloat("_Invert", isOnToggle);
        }
        if (isInvert.isOn == true)
        {
            isOnToggle = 1;
            material.SetFloat("_Invert", isOnToggle);
        }
    }
}
