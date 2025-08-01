using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timing : MonoBehaviour
{
    public List<GameObject> upNoteList = new List<GameObject>();
    public List<GameObject> downNoteList = new List<GameObject>();
    public List<GameObject> upDownNoteList = new List<GameObject>();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitW()
    {
        if (upNoteList == null) return;

        Debug.Log("1");
    }
    public void HitS()
    {
        if (downNoteList == null) return;
        
        Debug.Log("2");
    }
    public void HitB()
    {
        if (upDownNoteList == null) return;

        Debug.Log("3");
    }
}
