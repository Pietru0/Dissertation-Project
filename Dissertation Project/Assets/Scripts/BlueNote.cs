using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueNote : MonoBehaviour
{
    public bool canPress;

    public KeyCode keyPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyPress))
        {
            if (canPress)
            {
                gameObject.SetActive(false);
                GameManager.instance.HitNote();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(other.tag == "blueNote")
            {
                canPress = true;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        //if gameobject is active
        if(other.tag == "blueNote" && gameObject.activeSelf)
        {
            canPress = false;
            GameManager.instance.MissNote();
        }
    }
}
