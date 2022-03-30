using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    private float travelSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * travelSpeed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        travelSpeed = speed;
    }
}
