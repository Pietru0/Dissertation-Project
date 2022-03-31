using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NoteData))]
public class NoteDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        NoteData data = target as NoteData;
        if (GUILayout.Button("Parse"))
        {
            float x = 60f / data.BPM;

            float currentTime = 0;
            List<NoteData.NoteInfo> notes = new List<NoteData.NoteInfo>();

            string[] allNotes = data.noteSequence.Split('\n');
            foreach (string note in allNotes)
            {
                if (note.Trim() == ",") continue;
                NoteData.NoteColor colorToAdd = NoteData.NoteColor.Red;
                if (note.Trim() == "1000")
                {
                    colorToAdd = NoteData.NoteColor.Green;
                }
                else if (note.Trim() == "0100")
                {
                    colorToAdd = NoteData.NoteColor.Blue;
                }
                else if (note.Trim() == "0010")
                {
                    colorToAdd = (NoteData.NoteColor) Random.Range(0, 3);
                }

                //issue found: every "0000" is counting as red, try and solve this


                currentTime += x;
                notes.Add(new NoteData.NoteInfo(){
                    color = colorToAdd,
                    timeStamp = currentTime
                });
            }

            data.notes = notes.ToArray();
        }
    }
}
