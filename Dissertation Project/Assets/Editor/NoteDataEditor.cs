using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

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
            List<string> beatList = beats.ToList();
            //changed to list in order to be able to add items into it

            if (beats.Length == 4)
            {
                for (int i=0;i<(beats.Length*3); i++)
                {
                    //beats.Length should be 4; 4*3 = 12
                    //add new line and '0000' 12 times
                    beatList.Add("\n0000");
                    //which should total to 16
                }
                //beats = "0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000\n0000".Split('\n');
                Debug.Log("List Count (4): "+ beatList.Count);
                //number of "0000" in list
            }
            data.notes = notes.ToArray();
        }
    }
}
