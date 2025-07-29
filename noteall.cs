using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteall : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0;

    [SerializeField] Transform upNoteAppear = null;
    [SerializeField] Transform downNoteAppear = null;
    [SerializeField] GameObject goNote = null;

    timing theTimgManager;

    // Start is called before the first frame update
    void Start()
    {
        theTimgManager = GetComponent<timing>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        float upDown = Random.value;

        if (currentTime >= 60d / bpm)
        {
            if (upDown > 0.5)
            {
                GameObject upNote = Instantiate(goNote, upNoteAppear.position, Quaternion.identity);
                upNote.transform.SetParent(this.transform);
                theTimgManager.boxNoteList.Add(upNote);
            }
            else
            {
                GameObject downNote = Instantiate(goNote, downNoteAppear.position, Quaternion.identity);
                downNote.transform.SetParent(this.transform);
                theTimgManager.boxNoteList.Add(downNote);
            }

            currentTime -= 60d / bpm;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("note"))
        {
            theTimgManager.boxNoteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Miss");
        }
    }
}
