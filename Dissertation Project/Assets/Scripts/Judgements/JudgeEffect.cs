using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeEffect : MonoBehaviour
{
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
