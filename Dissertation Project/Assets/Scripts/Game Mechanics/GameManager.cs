﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
[Header("Music")]
    public AudioSource music;

[Header("Game Controller")]    
    public bool startMusic;

    public NoteScroller noteScroll;

    public NoteCreator noteCreation;

    public static GameManager instance;

[Header("Scoring")]
    
    public Text scoreText;
    public int scoreTotal;
    public int goodNote = 100;
    public int perfectNote = 150;

[Header("Score Multiplier")]
    public Text multiplierText;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multipliers;

[Header("Results")]
    [SerializeField] private string songName;
    [SerializeField] private string authorName;
    [SerializeField] private float totalNotes;
    [SerializeField] private float goodHits;
    [SerializeField] private float perfectHits;
    [SerializeField] private float missedHits;

    public GameObject resultsWindow;
    public Text percentage, goodText, perfectText, missText, rankText, finalScoreText, maxComboText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //making it so only one instance of GameManager can be present at all times
        //to call this in other scripts, always use GameManager.instance.function();
        
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startMusic)
        {
            if(Input.anyKeyDown)
            {
                startMusic = true;
                noteScroll.songStarted = true;
                music.PlayDelayed(2);
                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "Song1")
                {
                    noteCreation.Song1();
                    
                    totalNotes = 
                    FindObjectsOfType<GreenNote>().Length+
                    FindObjectsOfType<BlueNote>().Length+
                    FindObjectsOfType<RedNote>().Length;
                    //count total amount of notes in the scene after they are instantiated
                    //this will be used to calculate a rough estimate of %

                    songName = "Happy Rock";
                    authorName = "Benjamin C.";
                    //set name and author according to song
                }
            }
        }

        else
            {
                if (!music.isPlaying && !resultsWindow.activeInHierarchy)
                //if music is not playing and results window is not active in hierarchy
                {
                    resultsWindow.SetActive(true);

                    goodText.text = goodHits.ToString();
                    perfectText.text = perfectHits.ToString();
                    missText.text = missedHits.ToString();
                    finalScoreText.text = scoreTotal.ToString();

                    float totalHits = (perfectHits + (goodHits/1.5f));
                    //good hits are divided by 1.5 so that each good counts as 1.5 times less percentage
                    //than a perfect hit would
                    float percentHit = (totalHits / totalNotes) * 100f;

                    percentage.text = percentHit.ToString("F2") + "%";

                    string rankValue = "F";

                    if (percentHit > 50)
                    {
                        rankValue = "D";

                        if (percentHit > 60)
                        {
                            rankValue = "C";

                            if (percentHit > 70)
                            {
                                rankValue = "B";

                                if (percentHit > 85)
                                {
                                    rankValue = "A";

                                    if (percentHit > 95)
                                    {
                                        rankValue = "S";
                                    }
                                }
                            }
                        }
                    }
                    rankText.text = rankValue;
                    
                }
            }
    }

    public void HitNote()
    {
        Debug.Log("Hit note");
        
        if (currentMultiplier - 1 < multipliers.Length)
        {
            multiplierTracker++;

            if (multipliers[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        //in simple terms, this will track the amount of combo required
        //to move onto the next mutliplier threshold (x1, x2, x3 etc..)
        //e.g 25 combo will ramp up the score multiplier from x1 to x2

        multiplierText.text = "Multiplier: x" + currentMultiplier;

        //scoreTotal += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + scoreTotal;
        //register the note as HIT and update the current score
    }

    public void GoodHit()
    {
        scoreTotal += goodNote * currentMultiplier;
        HitNote();

        goodHits++;
    }

    public void PerfectHit()
    {
        scoreTotal += perfectNote * currentMultiplier;
        HitNote();

        perfectHits++;
    }

    public void MissNote()
    {
        Debug.Log("Miss Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
        //register the note as MISS and reset multipliers

        missedHits++;
    }
}
