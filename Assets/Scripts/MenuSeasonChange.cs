using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSeasonChange : MonoBehaviour
{

    public Image logo_main;
    public Image logo_play;

    public Image main_bg;
    public Image play_bg;
    public Image options_bg;
    public Image collection_bg;
    public Image full_bg;


    public Sprite gxbg;
    public Sprite dmbg;
    public Sprite DM_logo;
    public Sprite GX_logo;





    void Start()
    {
 

       
            if (PlayerPrefs.GetString("Series") == "GX")
                {
            logo_main.sprite = GX_logo;
            logo_main.rectTransform.sizeDelta = new Vector2(300, 140);
            logo_play.sprite = GX_logo;
            logo_play.rectTransform.sizeDelta = new Vector2(300, 140);

            main_bg.sprite = gxbg;
            play_bg.sprite = gxbg;
            options_bg.sprite = gxbg;
            collection_bg.sprite = gxbg;
            full_bg.sprite = gxbg;



        } else {
            logo_main.sprite = DM_logo;
            logo_main.rectTransform.sizeDelta = new Vector2(300, 100);
            logo_play.sprite = DM_logo;
            logo_play.rectTransform.sizeDelta = new Vector2(300, 100);

            main_bg.sprite = dmbg;
            play_bg.sprite = dmbg;
            options_bg.sprite = dmbg;
            collection_bg.sprite = dmbg;
            full_bg.sprite = dmbg;
        }
               
            



        


    }






}
