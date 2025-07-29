using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    timing theTimingMager;

    // Start is called before the first frame update
    void Start()
    {
        theTimingMager = FindObjectOfType<timing>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            theTimingMager.CheckTimingW();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            theTimingMager.CheckTimingS();

        }
    }
}
