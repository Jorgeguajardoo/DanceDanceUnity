using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class testDriver : MonoBehaviour
{
    private int frames, nextSpawnFrame, noteToRead;
    private System.Random rand;
    public GameObject note;
    public TextAsset noteFile;
    private No[] notesToRead;
    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
        rand = new System.Random();
        //play music
    }

    void OnEnable()
    {
        this.Start();
        Debug.Log(noteFile.text);

        NoteArray asdf = new NoteArray();
        JsonUtility.FromJsonOverwrite(noteFile.text, asdf);
        notesToRead = asdf.noteArray as No[];
        Debug.Log(notesToRead.Length);
        foreach(No n in notesToRead)
        {
            Debug.Log(n.frameoffset + " " + n.positionX);
        }
        if (notesToRead.Length < 1)
        {
            Debug.LogError("no notes are spawned! driver for note spawning has been destroyed.");
            return;
        }
        noteToRead = 0;
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if (frames == nextSpawnFrame)
        {
            Debug.Log("SPAWNING NOTE: X POSITION " + notesToRead[noteToRead].positionX + " AT FRAMEOFFSET " + frames);
            Instantiate(note, new Vector3(notesToRead[noteToRead].positionX, 4.5F, 0), Quaternion.identity);
            noteToRead++;
            
            if (noteToRead >= notesToRead.Length)
            {
                frames++;
                //placeholder line to end music playing (idfk how to do this or anything audio related)
                //placeholder line to call a script to go to the results screen
                gameObject.SetActive(false);
                return; // (unreachable?)
            }
            nextSpawnFrame = notesToRead[noteToRead].frameoffset;
        }
        
        frames++;
        
    }

    /*[System.Serializable]
    private class Wrapper
    {
        public NoteArray ob;
    } ignore this, was here to make sure we weren't missing a wrapper set of parentheses in the json file, didn't work obviously */


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
}
