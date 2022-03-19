using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
[Header("Music")]
    public AudioSource music;

[Header("Game Controller")]    
    public bool startMusic;

    public NoteScroller noteScroll;

    public static GameManager instance;

[Header("Scoring")]
    
    public Text scoreText;
    public int scoreTotal;
    public int scorePerNote = 100;

[Header("Score Multiplier")]
    public Text multiplierText;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multipliers;

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

        scoreTotal += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + scoreTotal;
        //register the note as HIT and update the current score
    }

    public void MissNote()
    {
        Debug.Log("Miss Note");

        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
        //register the note as MISS and reset multipliers
    }
}
