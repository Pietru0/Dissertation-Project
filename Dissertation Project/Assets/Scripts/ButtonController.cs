using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite defButton;
    public Sprite pressedButton;

    public GameObject laneLight;

    public KeyCode keysPress;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keysPress))
        {
            sr.sprite = pressedButton;
            laneLight.SetActive(true);
        }

        if (Input.GetKeyUp(keysPress))
        {
            sr.sprite = defButton;
            laneLight.SetActive(false);
        }
    }
}
