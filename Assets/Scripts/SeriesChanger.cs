using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SeriesChanger : MonoBehaviour
{
    public GameObject series_panel;
    public GameObject series_panel_gx;
    public Image locked;
    public Image locked_gx;
    public Canvas DM_canvas;
    public Canvas GX_canvas;


    public AudioClip DM_theme;
    public AudioClip GX_theme;


    void Start()
    {
        if(googleSignIn.story_progress>=7)
        {
            locked.enabled = false;
            locked_gx.enabled = false;
        } else
        {
            locked.enabled = true;
            locked_gx.enabled = true;
        }

        if(PlayerPrefs.GetString("Series") == "GX")
        {
            GX_canvas.enabled = true;
            DM_canvas.enabled = false;
        } else
        {
            GX_canvas.enabled = false;
            DM_canvas.enabled = true;
        }


    }

  

   
    public void changeSeriesButton()
    {
        if (PlayerPrefs.GetString("Series") == "GX")
        {
            series_panel_gx.gameObject.SetActive(true);
        } else
        {
            series_panel.gameObject.SetActive(true);
        }
         
    }


    public void cancelButton()
    {
        series_panel.gameObject.SetActive(false);
    }



    public void cancelGXButton()
    {
        series_panel_gx.gameObject.SetActive(false);
    }

    public void DuelMonstersClicked()
    {

        ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
        ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().clip = DM_theme;


        PlayerPrefs.SetString("Series", "DM");
       series_panel.gameObject.SetActive(false);
        GX_canvas.enabled = false;
        DM_canvas.enabled = true;
    }

    public void GXClicked()
    {
        if (googleSignIn.story_progress >= 7)
        {
            ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Stop();
            ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().clip = GX_theme;


            PlayerPrefs.SetString("Series", "GX");
            if (googleSignIn.story_progress == 7)
            {
                googleSignIn.story_progress++;
                SceneManager.LoadScene(5);
            }
            else
            {
                series_panel_gx.gameObject.SetActive(false);
                GX_canvas.enabled = true;
                DM_canvas.enabled = false;
            }
        }
     

    }



}
