using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMusicPreferences : MonoBehaviour
{

    public Toggle audiotoggle;



    void Update()
    {
        var music = PlayerPrefs.GetString("Music", "Default value");
        if (music.Equals("yes"))
        {
            audiotoggle.isOn = true;
        }
        if (music.Equals("no"))
        {
            audiotoggle.isOn = false;
        }
    }


}
