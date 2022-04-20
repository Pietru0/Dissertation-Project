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
            int count = 0;
            List<NoteData.NoteInfo> notes = new List<NoteData.NoteInfo>();

            string[] allNotes = data.noteSequence.Split('\n');
            foreach (string note in allNotes)
            {
                if (note.Trim() == ",") continue;
                currentTime += x;
                if (note.Trim() == "0000") continue;
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
                    colorToAdd = NoteData.NoteColor.Red;
                }

                
                notes.Add(new NoteData.NoteInfo(){
                    color = colorToAdd,
                    timeStamp = currentTime
                });
            }

            //counts the number of lines before a comma is seen
            //if a comma is seen, reset counter
            string[] allLines = data.noteSequence.Split('\n');
            foreach (string line in allLines)
            {
                if (line.Trim() ==",")
                {
                    Debug.Log("Lines: " + count);
                    count = 0;
                }

                else
                {
                    count++;
                }
            }
            //the only problem left to solve is to count this during live gameplay

            data.notes = notes.ToArray();
        }
    }
}
