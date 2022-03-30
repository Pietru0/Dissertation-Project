using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NoteCreator : MonoBehaviour
{
    [Header("Prefabs")]
    public NoteScroller red;
    public NoteScroller green;
    public NoteScroller blue;

    public Transform redTarget, greenTarget, blueTarget;
    public float spawnOnX = 15;
    public float travelSpeed = 10;

    public NoteData noteData;
    private NoteData.NoteInfo nextNote;

    [System.NonSerialized] public AudioSource audioSource;
    private float lookAhead;

    private float timer = -5;
    private int noteIndex = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = noteData.songFile;
        audioSource.PlayDelayed(5.5f);

        lookAhead = (spawnOnX - redTarget.position.x) / travelSpeed;
        nextNote = noteData.GetNote(noteIndex);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer + lookAhead >= nextNote.timeStamp && noteIndex < noteData.NoteCount)
        {
            // generate a note and store the next one.
            SpawnNote();

            noteIndex++;
            nextNote = noteData.GetNote(noteIndex);
        }
    }

    void SpawnNote()
    {
        Transform target = redTarget;
        NoteScroller noteToSpawn = red;

        if (nextNote.color == NoteData.NoteColor.Green)
        {
            target = greenTarget;
            noteToSpawn = green;
        }
        else if (nextNote.color == NoteData.NoteColor.Blue)
        {
            target = blueTarget;
            noteToSpawn = blue;
        }

        Vector3 pos = target.position;
        pos.x = spawnOnX;

        NoteScroller scroller = Instantiate(noteToSpawn, pos, Quaternion.identity);
        scroller.SetSpeed(travelSpeed);
        GameManager.instance.totalNotes++;
    }
}
