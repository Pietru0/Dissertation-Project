using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float BPM;

    public bool songStarted;

    // Start is called before the first frame update
    void Start()
    {
        BPM = BPM / 60;
        //setting how fast notes should move per second
    }

    // Update is called once per frame
    void Update()
    {
        if (!songStarted)
        {
            /*if(Input.anyKeyDown)
            {
                songStarted = true;
            }*/
        }

        else
        {
            transform.position -= new Vector3(BPM * Time.deltaTime, 0f);
            //scroll notes at y-axis according to set BPM
        }
    }
}
