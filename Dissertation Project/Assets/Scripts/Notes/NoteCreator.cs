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
        Instantiate(green,new Vector3(1f,0f,0f),Quaternion.Euler(0f,0f,-90f));
        Instantiate(green,new Vector3(2f,0f,0f),Quaternion.Euler(0f,0f,-90f));
        Instantiate(green,new Vector3(3f,0f,0f),Quaternion.Euler(0f,0f,-90f));
        Instantiate(green,new Vector3(4f,0f,0f),Quaternion.Euler(0f,0f,-90f));
    }
}
