using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidBackButton : MonoBehaviour
{


    public int SceneIndex;
    public static bool gotogame = false;
    

  


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (SceneIndex == 0)
            {
                if (GameObject.Find("Canvas_main").GetComponent<Canvas>().isActiveAndEnabled)
                {
                    //  Application.Quit();
                    AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                    activity.Call<bool>("moveTaskToBack", true);
                }
                else
                {
                    GameObject.Find("Canvas_main").GetComponent<Canvas>().enabled = true;
                    GameObject.Find("Canvas_game").GetComponent<Canvas>().enabled = false;
                    GameObject.Find("Canvas_collection").GetComponent<Canvas>().enabled = false;
                    GameObject.Find("Canvas_options").GetComponent<Canvas>().enabled = false;
                    GameObject.Find("Canvas_fullscreencard").GetComponent<Canvas>().enabled = false;
                }

            }


            if (SceneIndex == 1)
            {
                gotogame = true;
                SceneManager.LoadScene(0);
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music.Equals("yes"))
                {
                    ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().UnPause();
                }
            }

         
       

            if (SceneIndex == 2)
            {
                SceneManager.LoadScene(3);
            }

            if(SceneIndex == 6)
            {
                SceneManager.LoadScene(7);
            }


                if (SceneIndex == 3)
            {


                gotogame = true;
                SceneManager.LoadScene(0);
                var music = PlayerPrefs.GetString("Music", "Default value");


                if (music.Equals("yes"))
                {
                    DiscoveryMusic.Instance.gameObject.GetComponent<AudioSource>().Stop();
                    ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().UnPause();
                }

            }


        }
    }
}
