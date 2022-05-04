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
            string line = data.noteSequence;
            List<string> finalBeats = new List<string>();
            string[] sections = line.Split(',');
            //section is the new line after each beat

            foreach (string section in sections)
            {
                List<string> beats = GetBeats(section);
                finalBeats.AddRange(beats);
            }
            //for each section, add a beat

            data.notesPreview = "";
            for (int i = 0; i < finalBeats.Count; i++)
            {
                data.notesPreview += $"{i + 1} - {finalBeats[i]}\n";
            }
            //for each beat, print the value

            float x = (60f / data.BPM)/4f;

            float currentTime = 0;
            List<NoteData.NoteInfo> notes = new List<NoteData.NoteInfo>();

            foreach (string note in finalBeats)
            {
                currentTime += x;
                if (note.Trim() == "0000") continue;
                //if note is 0000, don't add a note
                NoteData.NoteColor colorToAdd = NoteData.NoteColor.Red;
                
                //if note is 1000, add a green note
                if (note.Trim() == "1000")
                {
                    colorToAdd = NoteData.NoteColor.Green;
                }

                //if note is 1000, add a blue note
                else if (note.Trim() == "0100")
                {
                    colorToAdd = NoteData.NoteColor.Blue;
                }

                //if note is 1000, add a red note
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
            List<string> beatsList = new List<string>(beats.Trim(new char[]{ '\n' }).Split('\n'));
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
