using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeCardFlipBackground : MonoBehaviour
{


    public Sprite DM_sprite;
    public Sprite GX_sprite;


    void Start()
    {

        if (PlayerPrefs.GetString("Series") == "GX")
        {
            GetComponent<SpriteRenderer>().sprite = GX_sprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = DM_sprite;
        }
    }


}
