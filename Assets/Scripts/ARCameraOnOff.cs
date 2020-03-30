using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARCameraOnOff : MonoBehaviour
{
    public void toggleChanged(Toggle cameratoggle)
    {
        if (cameratoggle.isOn)
        {
            PlayerPrefs.SetString("Camera", "yes");
        }
        else
        {
            PlayerPrefs.SetString("Camera", "no");
        }
    }
}
