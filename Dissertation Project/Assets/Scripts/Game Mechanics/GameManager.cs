using System.Collections;
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

    [SerializeField] private Text comboText;

    [SerializeField] private int combo = 0;

    [SerializeField] private int maxCombo = 0;

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
    [SerializeField] private Text songName;
    [SerializeField] private Text authorName;
    public float totalNotes;
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
                  
                totalNotes = 
                FindObjectsOfType<GreenNote>().Length+
                FindObjectsOfType<BlueNote>().Length+
                FindObjectsOfType<RedNote>().Length;
                //count total amount of notes in the scene after they are instantiated
                //this will be used to calculate a rough estimate of %  
            }
        }

        else
            {
                StartCoroutine(openResultsWindow());
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

        combo++;
        comboText.text = "Combo: " + combo.ToString();

        if (combo > maxCombo)
        {
            maxCombo++;
            maxCombo = combo;
        }

        else
        {
            maxCombo = maxCombo;
        }

        //if current combo ever exceeds the max combo, set the max combo equal to the current combo
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

        combo = 0;
        comboText.text = "Combo: " + combo.ToString();
        //if missing a note, max combo won't be affected and combo will go back to 0
        missedHits++;
    }

    IEnumerator openResultsWindow()
    {
        while (noteCreation.audioSource.isPlaying)
        {
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        resultsWindow.SetActive(true);
        comboText.gameObject.SetActive(false);      

        songName.text = "Happy Rock";
        authorName.text = "Benjamin Tissot";

        goodText.text = goodHits.ToString();
        perfectText.text = perfectHits.ToString();
        missText.text = missedHits.ToString();
        finalScoreText.text = scoreTotal.ToString();
        maxComboText.text = maxCombo.ToString();
        

        float totalHits = (perfectHits + (goodHits/1.5f));
        //good hits are divided by 1.5 so that each good counts as 1.5 times less percentage
        //than a perfect hit would
        float percentHit = (totalHits / totalNotes) * 100f;

        percentage.text = percentHit.ToString("F2") + "%";

        //ranking system

        string rankValue = "F";

        if (percentHit < 60)
        {
            rankValue = "D";
        }

        else if (percentHit < 70)
        {
            rankValue = "C";
        }

        else if (percentHit < 85)
        {
            rankValue = "B";
        }

        else if (percentHit < 95)
        {
            rankValue = "A";
        }

        else
        {
            rankValue = "S";
        }

        rankText.text = rankValue;

                    /* old ranking system
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
                    rankText.text = rankValue;*/
        

    }
}
