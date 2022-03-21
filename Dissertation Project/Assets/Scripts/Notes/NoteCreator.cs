using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCreator : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject blue;

    public void Song1()
    {
        Instantiate(green,new Vector3(0f,0f,0f),Quaternion.Euler(0f,0f,-90f));
        Instantiate(blue,new Vector3(1f,1.5f,0f),Quaternion.Euler(0f,0f,-90f));
        Instantiate(red,new Vector3(2f,-1.5f,0f),Quaternion.Euler(0f,0f,-90f));
        Instantiate(green,new Vector3(3f,0f,0f),Quaternion.Euler(0f,0f,-90f));
        Instantiate(green,new Vector3(4f,0f,0f),Quaternion.Euler(0f,0f,-90f));

        //blue Y = 1.5f
        //green Y = 0f
        //red Y = -1.5f

        //Whole Beat - 1 unit
        //Half Beat - 0.5 unit
        //Quarter Beat - 0.25 unit
        //Eighth Beat - 0.125 unit
        //Sixteenth Beat - 0.0625 unit

        //Third Beat - 0.33* unit
        //Sixth Beat - 0.167* unit 
    }
}
