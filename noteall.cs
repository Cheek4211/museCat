using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class noteall : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0;

    [SerializeField] Transform upNoteAppear = null;
    [SerializeField] Transform upNotedown = null;
    [SerializeField] Transform downNoteAppear = null;
    [SerializeField] Transform downNotedwon = null;
    [SerializeField] GameObject goNote = null;

    timing theTiming;
    AudioSource music;
    note theNote;
    bool playmusic = false;


    // Start is called before the first frame update
    void Start()
    {
        theTiming = GetComponent<timing>();
        music = GetComponent<AudioSource>();
        theNote = GetComponent<note>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playmusic)
        {
            musicStart();
        }
        NoteAppear();
         
    }
    public void NoteAppear()
    {
        currentTime += Time.deltaTime;
        float upDown = Random.value;

        if (currentTime >= 120d / bpm)
        {
            if (upDown < 0.40)
            {
                GameObject upNote = Instantiate(goNote, upNoteAppear.position, Quaternion.identity);
                upNote.transform.SetParent(this.transform);
                theTiming.upNoteList.Add(upNote);
            }
            else if (upDown > 0.60)
            {
                GameObject downNote = Instantiate(goNote, downNoteAppear.position, Quaternion.identity);
                downNote.transform.SetParent(this.transform);
                theTiming.downNoteList.Add(downNote);
            }
            else
            {
                GameObject upNote = Instantiate(goNote, upNoteAppear.position, Quaternion.identity);
                GameObject downNote = Instantiate(goNote, downNoteAppear.position, Quaternion.identity);
                upNote.transform.SetParent(this.transform);
                downNote.transform.SetParent(this.transform);
                theTiming.upDownNoteList.Add(upNote);
                theTiming.upDownNoteList.Add(downNote);

            }

            currentTime -= 120d / bpm;
        }
    }
    public void musicStart()
    {
        float Lengh = upNoteAppear.position.x - upNotedown.position.x;
        float noteSpeed = 4f;


        float noteDownTime = Lengh / noteSpeed;
        double oneBeat = 120d / bpm;

        if (Time.time > noteDownTime - oneBeat / 8 * 3)
        {
            music.Play();
            playmusic = true;
        }

    }
}
