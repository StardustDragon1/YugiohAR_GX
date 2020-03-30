using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SeriesChanger : MonoBehaviour
{
    public GameObject series_panel;
    public Image locked;
    public Canvas DM_canvas;
    public Canvas GX_canvas;


    void Start()
    {
        if(googleSignIn.story_progress>=7)
        {
            locked.enabled = false;
        } else
        {
            locked.enabled = true;
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
        series_panel.gameObject.SetActive(true);
    }


    public void cancelButton()
    {
        series_panel.gameObject.SetActive(false);
    }

    public void DuelMonstersClicked()
    {
       PlayerPrefs.SetString("Series", "DM");
       series_panel.gameObject.SetActive(false);
    }

    public void GXClicked()
    {
        PlayerPrefs.SetString("Series", "GX");
        series_panel.gameObject.SetActive(false);
    }



}
