using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float BPM;
    private float travelSpeed;
    public bool songStarted;

    [SerializeField] private float songTimer = 0;

    [SerializeField] private float startPos = 15;
    [SerializeField] private Transform markerPos;

    private float totalTime;
    NoteData.NoteInfo nextNote;

    // Start is called before the first frame update
    void Start()
    {
        travelSpeed = BPM / 60;
        totalTime = (startPos - markerPos.position.x) / travelSpeed;
        Debug.Log(totalTime);
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
            songTimer+=Time.deltaTime;
            transform.position -= new Vector3(travelSpeed * Time.deltaTime, 0f);
            //scroll notes at y-axis according to set BPM
        }


    }
}
