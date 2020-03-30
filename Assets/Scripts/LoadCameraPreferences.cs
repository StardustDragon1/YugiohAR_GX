using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadCameraPreferences : MonoBehaviour
{
    public Toggle cameratoggle;




    void Update()
    {
        var cam = PlayerPrefs.GetString("Camera", "Default value");
        if (cam == "yes" || cam == "Default value")
        {
            cameratoggle.isOn = true;
        }
        if (cam == "no")
        {
            cameratoggle.isOn = false;
        }
    }

}
