using Assets.Scripts;
using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCard : MonoBehaviour
{

    public int fps = 60;
    public float RotateDegreePerSecond = 180f;
    public bool IsFaceUp = false;

    const float FLIP_LIMIT_DEGREE = 180f;

    float waitTime;
    bool IsAnimationProcessing = false;

    public Button back;
    public Text obtained;
    public static string obtained_card_string = "";



    void Start()
    {
        waitTime = 1.0f / fps;
    }

    void OnMouseDown()
    {
       if(IsAnimationProcessing)
        {
            return;
        }
        StartCoroutine(flip() );
    }

    IEnumerator flip()
    {
        IsAnimationProcessing = true;

        bool done = false;
        while(!done)
        {
            float degree = RotateDegreePerSecond * Time.deltaTime;

            if(IsFaceUp)
            {
                degree = -degree;
            }

            transform.Rotate(new Vector3(0,degree,0));

            if(FLIP_LIMIT_DEGREE < transform.eulerAngles.y)
            {
                obtained.text = obtained_card_string;

                transform.Rotate(new Vector3(0, -degree, 0));

                obtained.gameObject.SetActive(true);
                back.gameObject.SetActive(true);

            }

            yield return new WaitForSeconds(waitTime);
        }

        IsFaceUp = !IsFaceUp;
        IsAnimationProcessing = false;
    }



}
