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


    public Text gx_chapter1;
    public Text gx_chapter2;
    public Text gx_chapter3;
    public Text gx_chapter4;
    public Text gx_chapter5;
    public Text gx_chapter6;



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



            case 8:
                gx_chapter1.text = "";
                gx_chapter2.text = "LOCKED";
                gx_chapter3.text = "LOCKED";
                gx_chapter4.text = "LOCKED";
                gx_chapter5.text = "LOCKED";
                gx_chapter6.text = "LOCKED";
                break;
            case 9:
                gx_chapter1.text = "COMPLETED";
                gx_chapter2.text = "";
                gx_chapter3.text = "LOCKED";
                gx_chapter4.text = "LOCKED";
                gx_chapter5.text = "LOCKED";
                gx_chapter6.text = "LOCKED";
                break;
            case 10:
                gx_chapter1.text = "COMPLETED";
                gx_chapter2.text = "COMPLETED";
                gx_chapter3.text = "";
                gx_chapter4.text = "LOCKED";
                gx_chapter5.text = "LOCKED";
                gx_chapter6.text = "LOCKED";
                break;
            case 11:
                gx_chapter1.text = "COMPLETED";
                gx_chapter2.text = "COMPLETED";
                gx_chapter3.text = "COMPLETED";
                gx_chapter4.text = "";
                gx_chapter5.text = "LOCKED";
                gx_chapter6.text = "LOCKED";
                break;
            case 12:
                gx_chapter1.text = "COMPLETED";
                gx_chapter2.text = "COMPLETED";
                gx_chapter3.text = "COMPLETED";
                gx_chapter4.text = "COMPLETED";
                gx_chapter5.text = "";
                gx_chapter6.text = "LOCKED";
                break;
            case 13:
                gx_chapter1.text = "COMPLETED";
                gx_chapter2.text = "COMPLETED";
                gx_chapter3.text = "COMPLETED";
                gx_chapter4.text = "COMPLETED";
                gx_chapter5.text = "COMPLETED";
                gx_chapter6.text = "";
                break;
            case 14:
                gx_chapter1.text = "COMPLETED";
                gx_chapter2.text = "COMPLETED";
                gx_chapter3.text = "COMPLETED";
                gx_chapter4.text = "COMPLETED";
                gx_chapter5.text = "COMPLETED";
                gx_chapter6.text = "COMPLETED";
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



    public void onGXFirstChapter()
    {
        if (googleSignIn.story_progress >= 8)
        {
            SceneManager.LoadScene(13);
        }
    }




    public void onGXSecondChapter()
    {
        if (googleSignIn.story_progress >= 9)
        {
            SceneManager.LoadScene(14);
        }
    }


    public void onGXThirdChapter()
    {
        if (googleSignIn.story_progress >= 10)
        {
            SceneManager.LoadScene(15);
        }
    }



    public void onGXFourthChapter()
    {
        if (googleSignIn.story_progress >= 11)
        {
            SceneManager.LoadScene(16);
        }
    }


    public void onGXFifthChapter()
    {
        if (googleSignIn.story_progress >= 12)
        {
            SceneManager.LoadScene(17);
        }
    }


    public void onGXSixthChapter()
    {
        if (googleSignIn.story_progress >= 13)
        {
            SceneManager.LoadScene(18);
        }
    }






}
