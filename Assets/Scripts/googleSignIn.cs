using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Firebase.Auth;
using Google;
using Proyecto26;
using System;
using UnityEngine.SceneManagement;


public class googleSignIn : MonoBehaviour
{

    public static FirebaseAuth auth;
    private FirebaseUser FBuser;

    public Button signinbutton;
    public Button signoutbutton;
    public Text nametext;
    public Text options;
    public Toggle toggle;
    public Toggle ar_toggle;
    public Image audio_img;
    public Image artext;
    public Button back;

    public static bool loadingdone = false;

    public static int story_progress;

    public static string username;
    public static string userid;

    public static Boolean[] userdata;
    public static Boolean[] locationdata;




    // Start is called before the first frame update
    void Start()
    {
        InitializeFirebase();
        nametext.text = "";
        toggle.gameObject.SetActive(true);
        ar_toggle.gameObject.SetActive(true);
        audio_img.gameObject.SetActive(true);
        artext.gameObject.SetActive(true);
        back.gameObject.SetActive(true);





        if ( userid != null)
        {
            signinbutton.gameObject.SetActive(false);
            signoutbutton.gameObject.SetActive(true);
            nametext.fontSize = 20;
            nametext.text = "WELCOME " + username;
        } else
        {
            signoutbutton.gameObject.SetActive(false);

            if (GoogleSignIn.Configuration == null)
            {

                GoogleSignIn.Configuration = new GoogleSignInConfiguration
                {
                    RequestIdToken = true,
                    WebClientId = "505464665583-4ohbreuk1g2e3g24bt9kg62q9c1t2mgt.apps.googleusercontent.com"
                };
            } else
            {
                username = FBuser.DisplayName.ToString();
                userid = FBuser.UserId.ToString();
                Player player = new Player();
                getPlayer(player);
            }


            if(LoadMenu.camefromcollection == true)
            {
                nametext.fontSize = 25;
                options.enabled = false;
                toggle.enabled = false;
                ar_toggle.enabled = false;
                audio_img.enabled = false;
                artext.enabled = false;
                nametext.text = "YOU MUST BE LOGGED IN TO VIEW YOUR COLLECTION";
            }
            if (LoadMenu.camefromdiscover == true)
            {
                nametext.fontSize = 25;
                options.enabled = false;
                toggle.enabled = false;
                ar_toggle.enabled = false;
                audio_img.enabled = false;
                artext.enabled = false;
                nametext.text = "YOU MUST BE LOGGED IN TO DISCOVER NEW CARDS";
            }
            if (LoadMenu.camefromjourney == true)
            {
                nametext.fontSize = 25;
                options.enabled = false;
                toggle.enabled = false;
                ar_toggle.enabled = false;
                audio_img.enabled = false;
                artext.enabled = false;
                nametext.text = "YOU MUST BE LOGGED IN TO ENTER STORY";
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }



    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }


    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != null)
        {
            bool signedIn = FBuser != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && FBuser != null)
            {

            }
            FBuser = auth.CurrentUser;
            if (signedIn)
            {

            }
        }
    }



    public void googleLogOutButton()
    {
        auth.SignOut();
        FBuser = null;
        userid = null;
        username = null;
        signinbutton.gameObject.SetActive(true);
        signoutbutton.gameObject.SetActive(false);
        nametext.text = "";
    }


    public void getPlayer(Player player)
    {

        RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + userid + ".json").Then(response =>
        {
            if (response == null)
            {
                
                RestClient.Post("https://yu-gi-oh-ar.firebaseio.com/" + userid + ".json", player);
            }
            getUserData();
        });
    }


   public void getUserData()
    {

        Player player = new Player();

        userdata = new Boolean[21];
        locationdata = new Boolean[21];
        RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + userid + ".json").Then(response =>
        {
            if(response == null)
            {
                getPlayer(player);
            }


            player = response;
            if (player.blue_acquired == false) { userdata[0] = false; } else { userdata[0] = true; }
            if (player.dark_acquired == false) { userdata[1] = false; } else { userdata[1] = true; }
            if (player.skull_acquired == false) { userdata[2] = false; } else { userdata[2] = true; }
            if (player.gaia_acquired == false) { userdata[3] = false; } else { userdata[3] = true; }
            if (player.obelisk_acquired == false) { userdata[4] = false; } else { userdata[4] = true; }
            if (player.neos_acquired == false) { userdata[5] = false; } else { userdata[5] = true; }
            if (player.golem_acquired == false) { userdata[6] = false; } else { userdata[6] = true; }
            if (player.archfiend == false) { userdata[7] = false; } else { userdata[7] = true; }
            if (player.black_luster == false) { userdata[8] = false; } else { userdata[8] = true; }
            if (player.black_rose == false) { userdata[9] = false; } else { userdata[9] = true; }
            if (player.cyber_end == false) { userdata[10] = false; } else { userdata[10] = true; }
            if (player.dark_magician_girl == false) { userdata[11] = false; } else { userdata[11] = true; }
            if (player.drill == false) { userdata[12] = false; } else { userdata[12] = true; }
            if (player.flame_wingman == false) { userdata[13] = false; } else { userdata[13] = true; }
            if (player.plasma == false) { userdata[14] = false; } else { userdata[14] = true; }
            if (player.rainbow_dragon == false) { userdata[15] = false; } else { userdata[15] = true; }
            if (player.red_eyes == false) { userdata[16] = false; } else { userdata[16] = true; }
            if (player.stardust == false) { userdata[17] = false; } else { userdata[17] = true; }
            if (player.utopia == false) { userdata[18] = false; } else { userdata[18] = true; }
            if (player.ra_acquired == false) { userdata[19] = false; } else { userdata[19] = true; }
            if (player.yubel_acquired == false) { userdata[20] = false; } else { userdata[20] = true; }


            if (player.mlyny == false) { locationdata[0] = false; } else { locationdata[0] = true; }
            if (player.ukf == false) { locationdata[1] = false; } else { locationdata[1] = true; }
            if (player.marian == false) { locationdata[2] = false; } else { locationdata[2] = true; }
            if (player.kniznica == false) { locationdata[3] = false; } else { locationdata[3] = true; }
            if (player.amfiteater == false) { locationdata[4] = false; } else { locationdata[4] = true; }
            if (player.pyramida == false) { locationdata[5] = false; } else { locationdata[5] = true; }

            if (player.agro == false) { locationdata[6] = false; } else { locationdata[6] = true; }
            if (player.kalvaria == false) { locationdata[7] = false; } else { locationdata[7] = true; }
            if (player.hala == false) { locationdata[8] = false; } else { locationdata[8] = true; }
            if (player.tesco== false) { locationdata[9] = false; } else { locationdata[9] = true; }
            if (player.hidepark == false) { locationdata[10] = false; } else { locationdata[10] = true; }
            if (player.zaba == false) { locationdata[11] = false; } else { locationdata[11] = true; }

            if (player.kostol== false) { locationdata[12] = false; } else { locationdata[12] = true; }
            if (player.hotel == false) { locationdata[13] = false; } else { locationdata[13] = true; }
            if (player.mostna == false) { locationdata[14] = false; } else { locationdata[14] = true; }
            if (player.fontana == false) { locationdata[15] = false; } else { locationdata[15] = true; }
            if (player.hrad == false) { locationdata[16] = false; } else { locationdata[16] = true; }
            if (player.corgon == false) { locationdata[17] = false; } else { locationdata[17] = true; }
            if (player.lavicka == false) { locationdata[18] = false; } else { locationdata[18] = true; }
            if (player.epicure == false) { locationdata[19] = false; } else { locationdata[19] = true; }
            if (player.spu == false) { locationdata[20] = false; } else { locationdata[20] = true; }

            story_progress = player.story_progress;

            if (LoadMenu.camefromcollection == true)
            {
                LoadMenu.camefromcollection = false;
                GameObject.Find("Canvas_main").GetComponent<Canvas>().enabled = false;
                GameObject.Find("Canvas_game").GetComponent<Canvas>().enabled = false;
                GameObject.Find("Canvas_collection").GetComponent<Canvas>().enabled = true;
                GameObject.Find("Canvas_options").GetComponent<Canvas>().enabled = false;
                GameObject.Find("Canvas_fullscreencard").GetComponent<Canvas>().enabled = false;
            }

            if (LoadMenu.camefromdiscover == true)
            {
                LoadMenu.camefromdiscover = false;
                SceneManager.LoadScene(3);
            }


            if (LoadMenu.camefromjourney == true)
            {
                LoadMenu.camefromjourney = false;
                if (story_progress == 7)
                {
                    SceneManager.LoadScene(7);
                }
                else
                {
                    SceneManager.LoadScene(5);
                }
            }
            loadingdone = true;

         
      
            nametext.text = "WELCOME " + FBuser.DisplayName.ToString();
        });

      

    }



    public void googleSignInButton()
     {
   
        Task<GoogleSignInUser> signIn = GoogleSignIn.DefaultInstance.SignIn();

        try
        {
            auth.SignOut();
            FBuser = null;
            userid = null;
            username = null;
        } catch(Exception e) { Debug.Log(e); }


         TaskCompletionSource<FirebaseUser> signInCompleted = new TaskCompletionSource<FirebaseUser>();
        signIn.ContinueWith(task =>
         {
             if (task.IsCanceled)
             {
                 signInCompleted.SetCanceled();
                 Debug.Log("TASK WAS CANCELLED");
             }
             else if (task.IsFaulted)
             {
                 signInCompleted.SetException(task.Exception);
                 Debug.Log("TASK ENDED WITH EXCEPTION_ " + task.Exception);
             }
             else
             {

                 Credential credential = GoogleAuthProvider.GetCredential(task.Result.IdToken, null);
                 auth.SignInWithCredentialAsync(credential).ContinueWith(authTask =>
                 {
                     if (authTask.IsCanceled)
                     {
                         signInCompleted.SetCanceled();
                         Debug.Log("TASK WAS CANCELLED2");
                     }
                     else if (authTask.IsFaulted)
                     {
                         signInCompleted.SetException(authTask.Exception);
                         Debug.Log("TASK ENDED WITH EXCEPTION2 " + task.Exception);
                     }
                     else
                     {
                         signInCompleted.SetResult(authTask.Result);
                         signinbutton.gameObject.SetActive(false);
                         signoutbutton.gameObject.SetActive(true);
                         if(LoadMenu.camefromcollection == true)
                         {
                                nametext.text = "LOADING COLLECTION";
                                options.text = "";
                                signoutbutton.gameObject.SetActive(false);
                                toggle.enabled = false;
                                ar_toggle.enabled = false;
                                audio_img.enabled = false;
                             artext.enabled = false;
                             back.gameObject.SetActive(false);


                         }
                         else
                         {

                             if (LoadMenu.camefromdiscover == true)
                             {
                                 nametext.text = "LOADING MAP";
                                 options.text = "";
                                 signoutbutton.gameObject.SetActive(false);
                                 toggle.enabled = false;
                                 ar_toggle.enabled = false;
                                 audio_img.enabled = false;
                                 artext.enabled = false;
                                 back.gameObject.SetActive(false);

                             } else {
                                 if (LoadMenu.camefromjourney == true)
                                 {
                                     nametext.text = "LOADING STORY";
                                     options.text = "";
                                     signoutbutton.gameObject.SetActive(false);
                                     toggle.enabled = false;
                                     ar_toggle.enabled = false;
                                     audio_img.enabled = false;
                                     artext.enabled = false;
                                     back.gameObject.SetActive(false);

                                 }
                                 else
                                 {
                                     nametext.text = "LOADING";
                                     signoutbutton.gameObject.SetActive(true);
                                 }
                             }

                             
                         }
                         loadingdone = false;
                         username = FBuser.DisplayName.ToString();
                         userid = FBuser.UserId.ToString();
                         Player player = new Player();
                         getPlayer(player);
                     }
                 });
             }
         }); 
     }
     
}

    
