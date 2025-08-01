using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    timing theTiming;
    AudioSource hit;


    // Start is called before the first frame update
    void Start()
    {
        theTiming = FindObjectOfType<timing>();
        hit = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.S))
        {
            theTiming.HitB();
            hit.Play();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            theTiming.HitW();
            hit.Play();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            theTiming.HitS();
            hit.Play();
        }
    }

}
