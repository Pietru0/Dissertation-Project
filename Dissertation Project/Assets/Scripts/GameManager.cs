using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool startMusic;

    public NoteScroller noteScroll;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //making it so only one instance of GameManager can be present at all times
        //to call this in other scripts, always use GameManager.instance.function();
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
    }

    public void MissNote()
    {
        Debug.Log("Miss Note");
    }
}
