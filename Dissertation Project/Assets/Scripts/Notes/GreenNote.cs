using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenNote : MonoBehaviour
{
[Header("Press")]
    public bool canPress;

    public KeyCode keyPress;

[Header("Judgements")]
    public GameObject goodJudge;
    public GameObject perfectJudge;
    public GameObject missJudge;

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

                if (transform.position.x > -5.96 || transform.position.x < -6.54)
                {
                    Debug.Log("Good Hit");
                    GameManager.instance.GoodHit();
                    Instantiate(goodJudge, goodJudge.transform.position, goodJudge.transform.rotation);
                }

                else
                {
                    Debug.Log("Perfect Hit");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectJudge, perfectJudge.transform.position, perfectJudge.transform.rotation);
                }
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
        //if gameobject is active
        if(other.tag == "greenNote" && gameObject.activeSelf)
        {
            canPress = false;
            GameManager.instance.MissNote();
            Instantiate(missJudge, missJudge.transform.position, missJudge.transform.rotation);
        }
    }
}
