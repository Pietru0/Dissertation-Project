using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            string[] beats = "0000\n0000\n0000\n0000".Split('\n');
            //Debug.Log("Initial Beat Count: "+beats.Length);
            
            if (beats.Length == 4)
            {
                for (int i=0; i>=4; i++)
                {
                    Debug.Log(i);
                    beats = beats.Concat(beats).ToArray();
                }
                //attempt to make a for loop which adds 3 empty beats

                //beats = "0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000".Split('\n');
                Debug.Log("Beats New Count: "+ beats.Length);
            }

            

            data.notes = notes.ToArray();
        }
    }
}
