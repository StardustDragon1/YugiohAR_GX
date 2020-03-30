using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapters : MonoBehaviour
{


    public Text chapter1;
    public Text chapter2;
    public Text chapter3;
    public Text chapter4;
    public Text chapter5;
    public Text chapter6;

    void Start()
    {
        if (ThemeSongScript.Instance != null)
        {
            ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
        }

        Screen.orientation = ScreenOrientation.LandscapeLeft;

        switch (googleSignIn.story_progress)
        {
            case 1:
                chapter1.text = "";
                chapter2.text = "LOCKED";
                chapter3.text = "LOCKED";
                chapter4.text = "LOCKED";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 2:
                chapter1.text = "COMPLETED";
                chapter2.text = "";
                chapter3.text = "LOCKED";
                chapter4.text = "LOCKED";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 3:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "";
                chapter4.text = "LOCKED";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 4:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 5:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "COMPLETED";
                chapter5.text = "";
                chapter6.text = "LOCKED";
                break;
            case 6:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "COMPLETED";
                chapter5.text = "COMPLETED";
                chapter6.text = "";
                break;
            case 7:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "COMPLETED";
                chapter5.text = "COMPLETED";
                chapter6.text = "COMPLETED";
                break;
        }
    }



   public void onFirstChapter()
    {
        if(googleSignIn.story_progress>=1)
        {
            SceneManager.LoadScene(6);
        }
    }

    public void onSecondChapter()
    {
        if (googleSignIn.story_progress >= 2)
        {
            SceneManager.LoadScene(8);
        }
    }

    public void onThirdChapter()
    {
        if (googleSignIn.story_progress >= 3)
        {
            SceneManager.LoadScene(9);
        }
    }


    public void onFourthChapter()
    {
        if (googleSignIn.story_progress >= 4)
        {
            SceneManager.LoadScene(10);
        }
    }


    public void onFifthChapter()
    {
        if (googleSignIn.story_progress >= 5)
        {
            SceneManager.LoadScene(11);
        }
    }


    public void onSixthChapter()
    {
        if (googleSignIn.story_progress >= 6)
        {
            SceneManager.LoadScene(12);
        }
    }


}
