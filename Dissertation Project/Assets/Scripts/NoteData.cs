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
        public NoteColor color;
        public float timeStamp;
    }

    public NoteInfo[] notes;

    public NoteInfo GetNote(int index)
    {
        return notes[index];
    }
}
