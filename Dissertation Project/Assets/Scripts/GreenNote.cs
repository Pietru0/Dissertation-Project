using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenNote : MonoBehaviour
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
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (Input.GetKey(KeyCode.S))
        {
            if(other.tag == "greenNote")
            {
                canPress = true;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "greenNote")
        {
            canPress = false;
        }
    }
}
