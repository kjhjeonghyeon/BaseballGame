using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.Core.Parsing;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Baseball : MonoBehaviour
{
    [SerializeField]

    public PlayableDirector[] play;//picher/stop/nun/strike/win/lose
    [Header("Q&A")]
    public GameObject qAPanel;
    GameObject qA;
    TMP_Text set;
    public GameObject skip;
    public Image Q;
    public Sprite[] imagesQ;
    public Button[] buttenA;
    public Sprite[] answerA;
    public Sprite[] wrongA;
    [Header("Score")]
    public Sprite[] score;//RG
    public Image[] scorePanel;//RG
    static int Round = 0;
    int outPoint = 0;
    bool skiped = false;
    bool random = false;
    static int answer = 0;
    static int key = -1;
    static int scoreNumber = -1;
    public AudioSource BGM;
    void Awake()
    {
        Round = 0;
        answer = 0;
        key = -1;
        scoreNumber = -1;
        // playOBJ[0].gameObject.SetActive(true);
        StartGame();
        qA = qAPanel.transform.GetChild(2).gameObject;
        set = qAPanel.transform.GetChild(0).GetComponent<TMP_Text>();
        //Debug.Log(qA.name);
        Screen.SetResolution(3840, 2160, true);
    }

    private void Start()
    {
        StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(answer + " " + key + " " + skiped);
        if (Input.GetKeyDown(KeyCode.P))
        {
            Chitkey();

        }
        
        PlayAndScore();
    }

    private void PlayAndScore()
    {
        if (key != -1)
        {

            play[1].Stop();


            if (answer == key)//strike
            {

                play[3].Play();
                Round++;
                scoreNumber++;
                scorePanel[scoreNumber].sprite = score[1];
                //skip.SetActive(true);

                //if (skiped)
                //{
                //    skip.SetActive(false);
                //    StartGame();
                //}
                //if (!skiped)
                //{

                Invoke("Picher", 17);


                // }


            }
            else if ((answer != key))//out
            {

                play[2].Play();
                Round++;
                outPoint++;
                scoreNumber++;
                scorePanel[scoreNumber].sprite = score[0];
                Invoke("StartGame", 4.5f);
                //play[2].Stop();


            }
            key = -1;
        }

        if (Round >= 7)
        {
            Invoke("Win", 3);
            Invoke("Intro", 8);
            BGM.Pause();

        }
        if (outPoint >= 3)
        {
            play[5].Play();
            Invoke("Intro", 5);
            BGM.Pause();
        }
    }

    void Chitkey()
    {
        set.text = "X";
        BGM.Pause();
        play[0].Stop();
        play[1].Stop();
        play[3].Stop();
        play[2].Stop();
        Win();
        Invoke("Intro", 8);
    }
    void Win()
    {
        play[4].Play();
    }
    void Intro()
    {
        SceneManager.LoadScene("Intro");
    }
    private void StartGame()
    {
        //  skip.SetActive(false);
        play[1].Stop();
        play[3].Stop();
        play[2].Stop();
        play[0].Play();
        Invoke("Picher", 1);

        //play[0].Stop();
    }

    void Picher()
    {
        int a = Round + 1;
        set.text = a.ToString();

        play[0].Stop();
        play[3].Stop();
        play[1].Play();

        qA.SetActive(true);
        Q.sprite = imagesQ[Round];


        int ran = Random.Range(0, 3);
        answer = ran;
        buttenA[ran].image.sprite = answerA[Round];
        random = false;
        //¹Ýº¹ÇØ »Ì±â
        for (; !random;)
        {

            int ran2 = Random.Range(0, 3);
            if (ran2 != ran)
            {

                int ran1Wrong = Random.Range(0, 14);
                buttenA[ran2].image.sprite = wrongA[ran1Wrong];



                int ran3 = Random.Range(0, 3);
                if ((ran3 != ran) && (ran3 != ran2))
                {

                    int ran2Wrong = Random.Range(0, 14);
                    buttenA[ran3].image.sprite = wrongA[ran2Wrong];
                    random = true;
                }
            }
        }




    }


    public void But1()
    {
        key = 0;
        // play[1].Stop();
        qA.SetActive(false);
    }
    public void But2()
    {
        key = 1;
        // play[1].Stop();
        qA.SetActive(false);
    }
    public void But3()
    {
        key = 2;
        // play[1].Stop();
        qA.SetActive(false);
    }
    //public void Skip()
    //{
    //    skiped = true;
    //}

}
