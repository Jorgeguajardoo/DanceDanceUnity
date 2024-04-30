using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class testDriver : MonoBehaviour
{
    private int frames, nextSpawnFrame, noteToRead;
    private System.Random rand;
    public GameObject note;
    public TextAsset noteFile, infoFile;
    private No[] notesToRead;
    private SongInfo info;
    private int frameoffset;
    public float notespeed, manualDelay;
    private AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        frames = -50;

        //something something find the audio file. need to discuss how to do this, or could just have a songlist thing that gets passed? not sure. could also attach to this object a list of all songs or something,
        //                                                                                                                                             then could have it be that you pull the specific object through
        //                                                                                                                                             .getcomponent and find or something of that sort. for now it is
        //                                                                                                                                             manually set before gameplay, will be part of menu implementation

        noteToRead = 0;

        NoteArray asdf = new NoteArray();
        JsonUtility.FromJsonOverwrite(noteFile.text, asdf);
        notesToRead = asdf.noteArray as No[];

        //Debug.Log(notesToRead.Length);
        //foreach (No n in notesToRead)
        //{
        //    Debug.Log(n.frameoffset + " " + n.positionX);
        //}

        if (notesToRead.Length < 1)
        {
            Debug.LogError("no notes are spawned! driver for note spawning has been destroyed.");
            return;
        }

        info = new SongInfo();
        //Debug.Log(infoFile.text);
        JsonUtility.FromJsonOverwrite(infoFile.text, info);
        //Debug.Log(info.songname + " " + info.notespeed) ;
        this.notespeed = (float)info.notespeed;
        
        Debug.Log("start frame: " + frames);
        audioData = (AudioSource)GameObject.Find("AudioPlayer").GetComponent<AudioSource>();
        float delay = (float)(.5+(4.2 / Math.Sqrt(notespeed)))+manualDelay;
        Debug.Log("delay:" + delay);
        nextSpawnFrame = notesToRead[noteToRead].frameoffset;
        Invoke("playAudio", delay);
        
    }

    void OnEnable()
    {
        // this.Start();
        //Debug.Log(noteFile.text
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (frames == nextSpawnFrame)
        {
            Debug.Log("SPAWNING NOTE: X POSITION " + notesToRead[noteToRead].positionX + " AT FRAMEOFFSET " + frames);
            Instantiate(note, new Vector3(notesToRead[noteToRead].positionX, 4.5F, 0), Quaternion.identity);
            noteToRead++;
            Debug.Log(noteToRead + " " + notesToRead.Length);
            if ((noteToRead >= notesToRead.Length))
            {
                frames++;
                //placeholder line to end music playing (idfk how to do this or anything audio related)
                //placeholder line to call a script to go to the results screen
                //gameObject.SetActive(false);
                return; // (unreachable?)
            }
            nextSpawnFrame = notesToRead[noteToRead].frameoffset;

        }
        
        
        frames++;
        
    }

    private void playAudio()
    {
        audioData.Play(0); //420/sqrt(notespeed) = frames
        Debug.LogWarning(frames);
    }

    [System.Serializable]
    private class NoteArray
    {
        public No[] noteArray;
    }

    [System.Serializable]
    private class No
    {
        public int frameoffset;
        public float positionX;
    }

    [System.Serializable]
    private class SongInfo
    {
        public string songname;
        public string duration;
        public int length;
        public string difficulty;
        public int songID;
        public string audiofile;
        public float notespeed;
    }
}
