using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SeriesChanger : MonoBehaviour
{
    public GameObject series_panel;
    public GameObject series_panel_gx;
    public Image locked;
    public Image locked_gx;
    public Canvas DM_canvas;
    public Canvas GX_canvas;


    void Start()
    {
        if(googleSignIn.story_progress>=7)
        {
            locked.enabled = false;
            locked_gx.enabled = false;
        } else
        {
            locked.enabled = false;
            locked_gx.enabled = false;
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

  
    void Update()
    {
        
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

    public void DuelMonstersClicked()
    {
       PlayerPrefs.SetString("Series", "DM");
       series_panel.gameObject.SetActive(false);
        GX_canvas.enabled = false;
        DM_canvas.enabled = true;
    }

    public void GXClicked()
    {
        PlayerPrefs.SetString("Series", "GX");
        series_panel_gx.gameObject.SetActive(false);
        GX_canvas.enabled = true;
        DM_canvas.enabled = false;

    }



}
