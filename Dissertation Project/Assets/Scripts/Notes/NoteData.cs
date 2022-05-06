using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/NoteData")]
public class NoteData : ScriptableObject
{

    public enum NoteColor
    {
        Red, Green, Blue
    }

    //class that cannot be null
    [System.Serializable]
    public struct NoteInfo
    {
        public float timeStamp;
        public NoteColor color;
    }

    public string songName;

    public AudioClip songFile;

    [Header("Setup")]
    public float BPM;

    [TextArea(3, 50)]
    public string noteSequence;


    [TextArea(3, 30)]
    public string notesPreview;

    public NoteInfo[] notes;

    public int NoteCount => notes.Length;

    public NoteInfo GetNote(int index)
    {
        return notes[index];
    }
}
