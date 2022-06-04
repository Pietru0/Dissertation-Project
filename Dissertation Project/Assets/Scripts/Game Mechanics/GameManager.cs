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
    [SerializeField] private string songName;
    [SerializeField] private string authorName;
    public float totalNotes;
    [SerializeField] private float goodHits;
    [SerializeField] private float perfectHits;
    [SerializeField] private float missedHits;

[Header("Pause")]
    public GameObject pauseWindow;
    [SerializeField] private bool isPaused = false;

[Header("Results Window")]
    public GameObject resultsWindow;
    public Text songNameR, authorNameR, percentage, goodText, perfectText, missText, rankText, finalScoreText, maxComboText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //making it so only one instance of GameManager can be present at all times
        //to call this in other scripts, always use GameManager.instance.function();
        
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        comboText.text = "";
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

        PauseGame();
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
        comboText.text = combo.ToString();

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
        comboText.text = combo.ToString();
        //if missing a note, max combo won't be affected and combo will go back to 0
        missedHits++;
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = true;

            if (noteCreation.audioSource.isPlaying && isPaused == true)
            {
                noteCreation.audioSource.Pause();
            }
            pauseWindow.SetActive(true);
            Time.timeScale = 0;
        } 
    }

    public void UnpauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            noteCreation.audioSource.Play();
            pauseWindow.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void exitLevel()
    {
        SceneManager.LoadScene("Song Selection");
        perfectHits = 0;
        goodHits = 0;
        missedHits = 0;
        noteCreation.audioSource.Stop();
    }

    IEnumerator openResultsWindow()
    {
        while (noteCreation.audioSource.isPlaying)
        {
            yield return null;
        }

        if (isPaused == false)
        {
            yield return new WaitForSeconds(1f);
            resultsWindow.SetActive(true);
            comboText.gameObject.SetActive(false);      

            songNameR.text = songName;
            authorNameR.text = authorName; 

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
            rankText.color = new Color32(161,21,171,255);

            if (percentHit < 60)
            {
                rankValue = "D";
                rankText.color = new Color32(158,16,18,255);
            }

            else if (percentHit < 70)
            {
                rankValue = "C";
                rankText.color = new Color32(177,92,242,255);
            }

            else if (percentHit < 85)
            {
                rankValue = "B";
                rankText.color = new Color32(20,183,252,255);
            }

            else if (percentHit < 95)
            {
                rankValue = "A";
                rankText.color = new Color32(101,252,20,255);
            }

            else
            {
                rankValue = "S";
                rankText.color = new Color32(254,215,20,255);
            }

            rankText.text = rankValue;
        }
    }
}
