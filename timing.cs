using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timing : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[] timingRect = null;
    [SerializeField] Transform upRect = null;
    [SerializeField] Transform downRect = null;
    Vector2[] timingBoxs = null;
    Vector2 upbox;
    Vector2 downbox;
    
    // Start is called before the first frame update
    void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];
        upbox = new Vector2();
        
        upbox = new Vector2(upRect.position.y - 1f, upRect.position.y + 1f);
        downbox = new Vector2(downRect.position.y - 1f, downRect.position.y + 1f);

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i]= new Vector2(Center.position.x - timingRect[i].rect.width / 2,
                              Center.position.x + timingRect[i].rect.width / 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckTimingW()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float notePosX= boxNoteList[i].transform.position.x;
            float notePosY= boxNoteList[i].transform.position.y;

            for (int j = 0; j < timingBoxs.Length; j++)
            {
                if (timingBoxs[j].x <= notePosX && notePosX <= timingBoxs[j].y 
                    && upbox.x <= notePosY && notePosY <= upbox.y)
                {
                    Destroy(boxNoteList[i]);
                    boxNoteList.RemoveAt(i);
                    Debug.Log("hit" + j );
                    return;
                }
                
            }
        }
        Debug.Log("Miss");
    }
    public void CheckTimingS()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float notePosX = boxNoteList[i].transform.position.x;
            float notePosY = boxNoteList[i].transform.position.y;

            for (int j = 0; j < timingBoxs.Length; j++)
            {
                if (timingBoxs[j].x <= notePosX && notePosX <= timingBoxs[j].y
                    && downbox.x <= notePosY && notePosY <= downbox.y)
                {
                    Destroy(boxNoteList[i]);
                    boxNoteList.RemoveAt(i);
                    Debug.Log("hit" + j);
                    return;
                }

            }
        }
        Debug.Log("Miss");
    }
}
