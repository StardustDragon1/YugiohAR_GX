using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSongScript : MonoBehaviour
{

    private static ThemeSongScript instance = null;
    public static ThemeSongScript Instance
    {
        get { return instance; }
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