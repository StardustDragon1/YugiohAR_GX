using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpCamera : MonoBehaviour
{



    void Start()
    {
        ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }


}
