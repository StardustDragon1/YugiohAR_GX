using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Android;

public class LoadMenu : MonoBehaviour
{

    public static bool camefromcollection;
    public static bool camefromdiscover;
    public static bool camefromjourney;

    public Canvas main;
    public Canvas game;
    public Canvas options;
    public Canvas collection;
    public Canvas card_scene;
    public Text nametext;
    public Text optionstext;
    public Image audiotext;
    public Image artext;
    public Toggle toggler;
    public Toggle ar_toggler;
    float currCountdownValue;

    private EventTrigger trigger;


    void Start()
    {

#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
#endif

        var music = PlayerPrefs.GetString("Music", "Default value");
        if (music.Equals("yes"))
        {
            if (DiscoveryMusic.Instance.gameObject.GetComponent<AudioSource>().isPlaying)
            {
                DiscoveryMusic.Instance.gameObject.GetComponent<AudioSource>().Stop();
            }


            if (!ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().isPlaying)
            {
                ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Play();
            }

         

        }


        if (!AndroidBackButton.gotogame)
        {
            main.enabled = true;
            game.enabled = false;
            options.enabled = false;
            collection.enabled = false;
            card_scene.enabled = false;
        } else
        {
            main.enabled = false;
            game.enabled = true;
            options.enabled = false;
            collection.enabled = false;
            card_scene.enabled = false;
            AndroidBackButton.gotogame = false;
        }
        

    }

    void showCard(int pocet)
    {
        GameObject card = GameObject.Find("FullCard");
        card.GetComponent<Button>().image.sprite = PopulateCollection.cards[PopulateCollection.card_clicked];

        card.AddComponent(typeof(EventTrigger));
        trigger = card.GetComponent<EventTrigger>();



        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => {
            main.enabled = false;
            game.enabled = false;
            card_scene.enabled = false;
            options.enabled = false;
            collection.enabled = true;
        });
        trigger.triggers.Add(entry);


    }


    public void SceneLoader(int SceneIndex)
    {
        camefromcollection = false;
        camefromdiscover = false;
        camefromjourney = false;

        if(SceneIndex == 1 )
        {
            SceneManager.LoadScene(SceneIndex);
        }



        if (SceneIndex == 3)
        {
          
            if (googleSignIn.userid == null)
            {
                main.enabled = false;
                game.enabled = false;
                card_scene.enabled = false;
                camefromdiscover = true;
                options.enabled = true;
                nametext.text = "YOU MUST BE LOGGED IN TO DISCOVER";
                toggler.gameObject.SetActive(false);
                ar_toggler.gameObject.SetActive(false);
                audiotext.enabled = false;
                artext.enabled = false;
                optionstext.enabled = false;
            } else
            {
                SceneManager.LoadScene(SceneIndex);
            }
          
        }
        else
        {
            if (SceneIndex == 5)
            {
                DialogueSystem.diag_inc = 0;

                if (googleSignIn.userid == null)
                {
                    main.enabled = false;
                    game.enabled = false;
                    card_scene.enabled = false;
                    camefromjourney = true;
                    options.enabled = true;
                    nametext.text = "YOU MUST BE LOGGED IN TO ENTER STORY";
                    toggler.gameObject.SetActive(false);
                    ar_toggler.gameObject.SetActive(false);
                    audiotext.enabled = false;
                    artext.enabled = false;
                    optionstext.enabled = false;
                }
                else
                {
                    if(googleSignIn.story_progress == 7)
                    {
                        SceneManager.LoadScene(7);
                    } else
                    {
                        SceneManager.LoadScene(SceneIndex);
                    }
                  
                }
            }
        }







    }

    public void showGameMenu()
    {
        main.enabled = false;
        game.enabled = true;
        options.enabled = false;
        collection.enabled = false;
        card_scene.enabled = false;
    }

    public void showMainMenu()
    {
        main.enabled = true;
        game.enabled = false;
        options.enabled = false;
        collection.enabled = false;
        card_scene.enabled = false;
    }

    public void showOptions()
    {
        main.enabled = false;
        game.enabled = false;
        card_scene.enabled = false;
        options.enabled = true;
        collection.enabled = false;
    }

    public void showCollection()
    {
        main.enabled = false;
        game.enabled = false;
        card_scene.enabled = false;
        options.enabled = false;
        if (googleSignIn.userid == null)
        {
            camefromcollection = true;
            options.enabled = true;
            nametext.text = "YOU MUST BE LOGGED IN TO VIEW YOUR COLLECTION";
            toggler.gameObject.SetActive(false);
            ar_toggler.gameObject.SetActive(false);
            audiotext.enabled = false;
            artext.enabled = false;
            optionstext.enabled = false;
        }
        else
        {

            if (googleSignIn.loadingdone == true)
            {
                collection.enabled = true;
            } else
            {
                StartCoroutine(StartCountdown());
            }

                
        }

    }


    public void Quit()
    {
        //Application.Quit();
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void showFullScreenCard()
    {
    
        GameObject.Find("Canvas_collection").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas_fullscreencard").GetComponent<Canvas>().enabled = true;
        showCard(21);
    }

    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            if(googleSignIn.loadingdone == true)
            {
                currCountdownValue = 0;
                countdownValue = 0;
                collection.enabled = true;
            }
            if(currCountdownValue==0)
            {
                collection.enabled = true;
            }

        }
    }





}
