using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Proyecto26;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{

    public UnityEngine.Video.VideoClip videoClip;
    public Image protagonist;
    public Image antagonist;
    public Canvas dialogueCanvas;
    public Text diag;
    private string music_pref; 

    public AudioSource audioSource;




    private VideoPlayer videoPlayer;

    private bool videoplaying = false;


    public static int diag_inc = 0;

    void Start()
    {
        music_pref  = PlayerPrefs.GetString("Music", "Default value");
        diag_inc = 0;

        if(googleSignIn.story_progress == 1)
        {
            chapterControl();
        }

        if (ThemeSongScript.Instance != null)
        {
            ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
        }
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (googleSignIn.story_progress == 0)
        {
              dialogueCanvas.enabled = false;
              GameObject camera = GameObject.Find("Main Camera");
              videoPlayer = camera.AddComponent<VideoPlayer>();
              videoPlayer.playOnAwake = true;
              videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
              videoPlayer.targetCameraAlpha = 1f;
              videoPlayer.clip = videoClip;
              videoplaying = true;
              videoPlayer.loopPointReached += EndReached;
        } 

    }


  

    void EndReached(VideoPlayer vp)
    {
        vp.enabled = false;
        videoplaying = false;
        dialogueCanvas.enabled = true;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && videoplaying)
        {
            videoPlayer.enabled = false;
            videoplaying = false;
            dialogueCanvas.enabled = true;
        }


            if (Input.GetMouseButtonDown(0) && googleSignIn.story_progress == 0 && !videoplaying)
        {
           StartCoroutine(FirstChapter());
        }
       

        if (Input.GetMouseButtonDown(0) && googleSignIn.story_progress == 2 && !videoplaying)
        {
            StartCoroutine(SecondChapter());
        }

        if (Input.GetMouseButtonDown(0) && googleSignIn.story_progress == 3 && !videoplaying)
        {
            StartCoroutine(ThirdChapter());
        }

        if (Input.GetMouseButtonDown(0) && googleSignIn.story_progress == 4 && !videoplaying)
        {
            StartCoroutine(FourthChapter());
        }

        if (Input.GetMouseButtonDown(0) && googleSignIn.story_progress == 5 && !videoplaying)
        {
            StartCoroutine(FifthChapter());
        }
        if (Input.GetMouseButtonDown(0) && googleSignIn.story_progress == 6 && !videoplaying)
        {
            StartCoroutine(SixthChapter());
        }
        if (Input.GetMouseButtonDown(0) && googleSignIn.story_progress == 7 && !videoplaying)
        {
            StartCoroutine(SeventhChapter());
        }


    }


    public IEnumerator FirstChapter()
    {


        switch (diag_inc)
        {
            case 0:
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music == "yes")
                {
                    audioSource.Play();
                }
                protagonist.sprite = Resources.Load<Sprite>("kaiba_dl");
                antagonist.sprite = Resources.Load<Sprite>("pegasus_dl");
                antagonist.gameObject.SetActive(true);
                protagonist.gameObject.SetActive(true);
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: Pegasus! Your games will end here and now. This madness will stop";
                diag_inc++;
                break;
            case 1:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Pegasus: Oh, Kaiba boy! You know nothing about my powers";
                diag_inc++;
                break;
            case 2:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: I know you are keeping Yugi locked, and I will save him, I owe him that much";
                diag_inc++;
                break;
            case 3:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Pegasus: Then you will have to face monsters you´ve never seen before dear Kaiba";
                diag_inc++;
                break;
            case 4:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: I am ready, are you?";
                diag_inc++;

                Player player = new Player();
                yield return new WaitForSeconds(1f);
                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 1;
                    googleSignIn.story_progress = 1;
                    if (music_pref == "yes")
                    {
                        audioSource.Stop();
                    }
                    chapterControl();
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });

              


                break;
        }
    }

    public IEnumerator SecondChapter()
    {
        switch (diag_inc)
        {
            case 0:
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music == "yes")
                {
                    audioSource.Play();
                }
                protagonist.sprite = Resources.Load<Sprite>("kaiba_dl");
                antagonist.sprite = Resources.Load<Sprite>("yugi_dl");
                antagonist.gameObject.SetActive(true);
                protagonist.gameObject.SetActive(true);
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: Yugi! What did Pegasus do to you?";
                diag_inc++;
                break;
            case 1:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Yami Yugi:  He merely showed me the way to my true potential";
                diag_inc++;
                break;
            case 2:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: We don´t have to do this";
                diag_inc++;
                break;
            case 3:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Yami Yugi: Yes we do, I challenge you to a duel of Shadow Games. I Summon Gaia The Fierce Knight";
                diag_inc++;
                break;
            case 4:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: oh great!";
                diag_inc++;

                Player player = new Player();
                yield return new WaitForSeconds(1f);

                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 2;
                    googleSignIn.story_progress = 2;
                    if (music_pref == "yes")
                    {
                        audioSource.Stop();
                    }
                    chapterControl();
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });

             

                break;
        }
    }


    public IEnumerator ThirdChapter()
    {




        switch (diag_inc)
        {
            case 0:
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music == "yes")
                {
                    audioSource.Play();
                }
                protagonist.sprite = Resources.Load<Sprite>("kaiba_dl");
                antagonist.sprite = Resources.Load<Sprite>("yugi_dl");
                antagonist.gameObject.SetActive(true);
                protagonist.gameObject.SetActive(true);
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: Yugi! are you alright?";
                diag_inc++;
                break;
            case 1:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Yami Yugi:  Yeah, thank you for saving me Kaiba";
                diag_inc++;
                break;
            case 2:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: Pegasus will pay for that he did to you";
                diag_inc++;
                break;
            case 3:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Yami Yugi: It couldn´t have been Pegasus, he doesn´t have mind control abbilities";
                diag_inc++;
                break;
            case 4:
                antagonist.sprite = Resources.Load<Sprite>("marik_dl");
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Marik: oh am I crashing a moment between you too?";
                diag_inc++;
                break;
            case 5:
                antagonist.sprite = Resources.Load<Sprite>("marik_dl");
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Kaiba: Marik, so you are behind this";
                diag_inc++;
                break;
            case 6:
                antagonist.sprite = Resources.Load<Sprite>("marik_dl");
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Marik: Tell me Kaiba, have you seen an Egyptian God before? I summon Obelisk the Tormentor!";
                diag_inc++;

                Player player = new Player();

                yield return new WaitForSeconds(1f);
                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 3;
                    googleSignIn.story_progress = 3;
                    if (music_pref == "yes")
                    {
                        audioSource.Stop();
                    }
                    chapterControl();
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });
              
               
                break;
        }
    }


    public IEnumerator FourthChapter()
    {
  
        switch (diag_inc)
        {
            case 0:
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music == "yes")
                {
                    audioSource.Play();
                }
                protagonist.sprite = Resources.Load<Sprite>("yugi_dl");
                antagonist.sprite = Resources.Load<Sprite>("bakura_dl");
                antagonist.gameObject.SetActive(true);
                protagonist.gameObject.SetActive(true);
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: Your Reign ends Marik!";
                diag_inc++;
                break;
            case 1:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Bakura:  Yeah, well he had a little part to play anyway";
                diag_inc++;
                break;
            case 2:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: Bakura??!!??";
                diag_inc++;
                break;
            case 3:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Bakura: Seen a ghost? Well not yet, it is time to fight your own monsters Yugi";
                diag_inc++;
                break;
            case 4:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Bakura: Summoned Skull! You know what to do!";
                diag_inc++;

                Player player = new Player();

                yield return new WaitForSeconds(1f);
                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 4;
                    googleSignIn.story_progress = 4;
                    if (music_pref == "yes")
                    {
                        audioSource.Stop();
                    }
                    chapterControl();
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });
                break;
        }
    }

    public IEnumerator FifthChapter()
    {

        switch (diag_inc)
        {
            case 0:
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music == "yes")
                {
                    audioSource.Play();
                }
                protagonist.sprite = Resources.Load<Sprite>("yugi_dl");
                antagonist.sprite = Resources.Load<Sprite>("pegasus_dl");
                antagonist.gameObject.SetActive(true);
                protagonist.gameObject.SetActive(true);
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: You can't control the Summoned Skull. It is my monster";
                diag_inc++;
                break;
            case 1:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Pegasus: Perhaps you will have more troubles fighting off your friend's monsters";
                diag_inc++;
                break;
            case 2:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: Throw whatever you want at me Pegasus, at the end you will lose";
                diag_inc++;
                break;
            case 3:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Pegasus: That is the spirit. Red Eyes Black Dragon attack!";
                diag_inc++;
                break;
            case 4:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: huh?!";
                diag_inc++;

                Player player = new Player();

                yield return new WaitForSeconds(1f);
                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 5;
                    googleSignIn.story_progress = 5;
                    if (music_pref == "yes")
                    {
                        audioSource.Stop();
                    }
                    chapterControl();
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });
                break;
        }
    }


    public IEnumerator SixthChapter()
    {

        switch (diag_inc)
        {
            case 0:
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music == "yes")
                {
                    audioSource.Play();
                }
                protagonist.sprite = Resources.Load<Sprite>("yugi_dl");
                antagonist.sprite = Resources.Load<Sprite>("pegasus_dl");
                antagonist.gameObject.SetActive(true);
                protagonist.gameObject.SetActive(true);
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: The Millenium Necklace is doing this, where is it?";
                diag_inc++;
                break;
            case 1:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Pegasus: oh I knew Kaiba would come save you, it was always there with him.";
                diag_inc++;
                break;
            case 2:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Pegasus: It was to see the battle of the century, the Dark Magician vs. The Blue Eyes";
                diag_inc++;
                break;
            case 3:
                antagonist.sprite = Resources.Load<Sprite>("kaiba_dl");
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Kaiba: I dont feel so well. Blue-Eyes White Lightning!";
                diag_inc++;
                break;
            case 4:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: Dark Magician Dark Magic attack!";
                diag_inc++;

                Player player = new Player();

                yield return new WaitForSeconds(1f);
                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 6;
                    googleSignIn.story_progress = 6;
                    if (music_pref == "yes")
                    {
                        audioSource.Stop();
                    }
                    chapterControl();
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });
                break;
        }
    }

    public IEnumerator SeventhChapter()
    {

        switch (diag_inc)
        {
            case 0:
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music == "yes")
                {
                    audioSource.Play();
                }
                protagonist.sprite = Resources.Load<Sprite>("yugi_dl");
                antagonist.sprite = Resources.Load<Sprite>("kaiba_dl");
                antagonist.gameObject.SetActive(true);
                protagonist.gameObject.SetActive(true);
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: Perhaps this is the end, the Millenium Necklace is broken";
                diag_inc++;
                break;
            case 1:
                antagonist.color = Color.white;
                protagonist.color = Color.black;
                diag.text = "Kaiba: Yeah, but maybe many corrupted monsters exist around the world that needs saving";
                diag_inc++;
                break;
            case 2:
                antagonist.color = Color.black;
                protagonist.color = Color.white;
                diag.text = "Yami Yugi: Let's do that! Lets save them and break Marik's spell on them!";
                diag_inc++;

                Player player = new Player();

                yield return new WaitForSeconds(1f);
                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 7;
                    googleSignIn.story_progress = 7;
                    if (music_pref == "yes")
                    {
                        audioSource.Stop();
                    }
                    chapterControl();
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });
                break;
        }
    }




    public void chapterControl()
    {
        SceneManager.LoadScene(7);
    }




 


}
