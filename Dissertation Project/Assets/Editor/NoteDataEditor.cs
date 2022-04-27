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
            string line = data.noteSequence;
            List<string> finalBeats = new List<string>();
            string[] sections = line.Split('\n');

            foreach (string section in sections)
            {
                List<string> beats = GetBeats(section);
                finalBeats.AddRange(beats);
            }

            foreach (string beat in finalBeats)
            {
                Debug.Log(beat);
            }

            float x = 60f / data.BPM;

            float currentTime = 0;
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

            data.notes = notes.ToArray();
        }
    }
        public static List<string> GetBeats(string beats)
        {
            List<string> beatsList = new List<string>(beats.Split('-'));
            //changed to list in order to be able to add items into it

            while (beatsList.Count < 16)
            {
                int beatsCount = beatsList.Count;
                for (int i=0; i<beatsCount; i++)
                {
                    beatsList.Insert(beatsList.Count - (i * 2), "0000");
                }
            }

            return beatsList;
        }
}
