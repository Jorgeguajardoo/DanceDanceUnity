using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class noteSpawner : MonoBehaviour
{
    private int frames;
    private int nextSpawnFrame;
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        frames = 0;
        // do the rest somewhere else
    }

    void OnEnable()
    {
        frames = 0;
        nextSpawnFrame = -1;
        if (note == null)
        {
            Debug.LogWarning("note object reference not insantiated. No notes will spawn!");
            Debug.LogAssertion("NOTE IS NULL, CODE WILL NOT RUN");
        }
        //play music
        //frame counting will begin
        //confirm that reading file is valid
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //if note is to be spawned:
        //    spawn note
        //    begin reading ahead for next note spawn. set nextspawn frame to what is read from file and then wait
        if(nextSpawnFrame == frames)
        {
            float positionX = 0; //read from the file and get the note here
            Instantiate(note, new Vector3(positionX, 4.5F, 0), Quaternion.identity);
        }
        frames++;
    }
}
