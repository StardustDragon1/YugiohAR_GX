using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSongScript : MonoBehaviour
{

    AudioSource audio_source;
    public AudioClip DM_theme;
    public AudioClip GX_theme;




    private static ThemeSongScript instance = null;
    public static ThemeSongScript Instance
    {
        get { return instance; }
    }

    void Start()
    {
        audio_source = gameObject.GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("Series") == "GX")
        {
            audio_source.clip = GX_theme;
            audio_source.Play();
        } else
        {
            audio_source.clip = DM_theme;
            audio_source.Play();
        }

    }


 


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}