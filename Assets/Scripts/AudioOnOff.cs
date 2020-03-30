using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOnOff : MonoBehaviour
{


    public void toggleChanged(Toggle audiotoggle)
    {
        if (audiotoggle.isOn)
        {
            PlayerPrefs.SetString("Music", "yes");
            ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            PlayerPrefs.SetString("Music", "no");
            ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
