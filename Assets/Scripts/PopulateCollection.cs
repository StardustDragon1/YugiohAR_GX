using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using Proyecto26;

public class PopulateCollection : MonoBehaviour
{
    public Canvas main;
    public Canvas game;
    public Canvas options;
    public Canvas collection;
    public Canvas card_scene;


    public static int card_clicked;

    public GameObject card;
    private LoadMenu lm;
    

    public int pocet;

    private bool popafterlog = false;


    public static Sprite[] cards;
    public static Sprite[] unobtained;

    






    void Start()
    {
        //  Populate();
    }

   
    void Update()
    {
        if(popafterlog == false && collection.isActiveAndEnabled)
        {

            Populate();
            popafterlog = true;
          collection.enabled = !true;
          collection.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(2);
            }
        }
        }








    public void Populate()
    {

        GameObject[] newObj;

       newObj = new GameObject[pocet];

       cards = new Sprite[pocet];
       unobtained = new Sprite[pocet];

       


        unobtained[0] = Resources.Load<Sprite>("blue_eyes_gray");
        unobtained[1] = Resources.Load<Sprite>("dark_magician_gray");
        unobtained[2] = Resources.Load<Sprite>("summoned_skull_gray");
        unobtained[3] = Resources.Load<Sprite>("gaia_gray");
        unobtained[4] = Resources.Load<Sprite>("obelisk_gray");
        unobtained[5] = Resources.Load<Sprite>("neos_gray");



        unobtained[6] = Resources.Load<Sprite>("ancient_gear_golem_gray");
        unobtained[7] = Resources.Load<Sprite>("archfiend_gray");
        unobtained[8] = Resources.Load<Sprite>("black_luster_gray");
        unobtained[9] = Resources.Load<Sprite>("black_rose_gray");
        unobtained[10] = Resources.Load<Sprite>("cyber_end_gray");
        unobtained[11] = Resources.Load<Sprite>("d_magician_girl_gray");
        unobtained[12] = Resources.Load<Sprite>("drill_gray");
        unobtained[13] = Resources.Load<Sprite>("elemental_hero_gray");
        unobtained[14] = Resources.Load<Sprite>("plasma_gray");
        unobtained[15] = Resources.Load<Sprite>("rainbow_dragon_gray");
        unobtained[16] = Resources.Load<Sprite>("red_eyes_gray");
        unobtained[17] = Resources.Load<Sprite>("stardust_gray");
        unobtained[18] = Resources.Load<Sprite>("utopia_gray");
        unobtained[19] = Resources.Load<Sprite>("winged_dragon_gray");
        unobtained[20] = Resources.Load<Sprite>("yubel_gray");


     
       

        cards[0] = Resources.Load<Sprite>("blue_eyes");
        cards[1] = Resources.Load<Sprite>("dark_magician");
        cards[2] = Resources.Load<Sprite>("summoned_skull");
        cards[3] = Resources.Load<Sprite>("gaia");
        cards[4] = Resources.Load<Sprite>("obelisk");
        cards[5] = Resources.Load<Sprite>("neos");
        cards[6] = Resources.Load<Sprite>("ancient_gear_golem");
        cards[7] = Resources.Load<Sprite>("archfiend");
        cards[8] = Resources.Load<Sprite>("black_luster");
        cards[9] = Resources.Load<Sprite>("black_rose");
        cards[10] = Resources.Load<Sprite>("cyber_end");
        cards[11] = Resources.Load<Sprite>("d_magician_girl");
        cards[12] = Resources.Load<Sprite>("drill");
        cards[13] = Resources.Load<Sprite>("elemental_hero");
        cards[14] = Resources.Load<Sprite>("plasma");
        cards[15] = Resources.Load<Sprite>("rainbow_dragon");
        cards[16] = Resources.Load<Sprite>("red_eyes");
        cards[17] = Resources.Load<Sprite>("stardust");
        cards[18] = Resources.Load<Sprite>("utopia");
        cards[19] = Resources.Load<Sprite>("winged_dragon");
        cards[20] = Resources.Load<Sprite>("yubel");



  

        for (int i=0; i< pocet;i++)
        {
            newObj[i] = (GameObject)Instantiate(card, transform);
            newObj[i].transform.SetParent(transform, false);
            var index = i;
            UnityEngine.Events.UnityAction action1 = () => { cardClicked(index); };
            newObj[i].GetComponent<Button>().onClick.AddListener(action1);

            if(googleSignIn.userdata != null && googleSignIn.userdata[i] == false)
            {
                newObj[i].GetComponent<Image>().sprite = unobtained[i];
            } else
            {
                newObj[i].GetComponent<Image>().sprite = cards[i];
            }


            


        }


        void cardClicked(int index)
        {
            card_clicked = index;
            lm = new LoadMenu();
            lm.showFullScreenCard();
            
        }


    }

   
}
