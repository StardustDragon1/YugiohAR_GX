using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    void Start()
    {
        ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

}
