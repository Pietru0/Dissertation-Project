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

    private AudioSource audioSource;
    private float lookAhead;

    private float timer = -5;
    private int noteIndex = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = noteData.songFile;
        audioSource.PlayDelayed(5);

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
    }

    //Happy Rock - Easy
    public void Song1()
    {
        /*Instantiate(green,new Vector3(0f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(4f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(8f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(12f,-0.1f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(16f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(20f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(24f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(28f,-1.7f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(32f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(36f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(40f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(44f,1.5f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(48f,-0.1f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(52f,1.5f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(56f,-0.1f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(60f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(64f,-1.7f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(68f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(72f,-0.1f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(76f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(80f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(84f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(88f,1.5f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(92f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(96f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(100f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(104f,-0.1f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(108f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(112f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(116f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(120f,-1.7f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(124f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(128f,-0.1f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(132f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(136f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(140f,1.5f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(144f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(148f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(152f,-0.1f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(156f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(160f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(164f,-1.7f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(168f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(172f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(176f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(180f,1.5f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(184f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(188f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(192f,-0.1f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(196f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(200f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(204f,-1.7f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(208f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(212f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(216f,-0.1f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(220f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(224f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(228f,-1.7f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(232f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(236f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(240f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(244f,1.5f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(248f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(252f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(256f,-0.1f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(260f,-0.1f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(264f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(268f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(272f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(276f,-1.7f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(280f,-0.1f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(284f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(288f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(292f,1.5f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(296f,1.5f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(300f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(304f,-1.7f,0f),Quaternion.identity);
        Instantiate(red,new Vector3(308f,-1.7f,0f),Quaternion.identity);
        Instantiate(blue,new Vector3(312f,1.5f,0f),Quaternion.identity);
        Instantiate(green,new Vector3(315.5f,-0.1f,0f),Quaternion.identity);*/




        //blue Y = 1.5f
        //green Y = 0f
        //red Y = -1.5f

        //Whole Beat - 1 unit
        //Half Beat - 0.5 unit
        //Quarter Beat - 0.25 unit
        //Eighth Beat - 0.125 unit
        //Sixteenth Beat - 0.0625 unit

        //Third Beat - 0.33* unit
        //Sixth Beat - 0.167* unit 
    }
}
