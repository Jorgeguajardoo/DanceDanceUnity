using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class notehitanimationscript : MonoBehaviour
{
    private int frames;
    private float var;
    // Start is called before the first frame update
    void Start()
    {
        var = .6f;
        frames = 0;
        gameObject.transform.localScale = new Vector3(.2f, .2f, 1);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f-var);
    }

    // Update is called once per frame
    void Update()
    {
        if(frames >= 100)
        {
            Destroy(gameObject);
        }
        var = (float)(Math.Pow(var,.7));
        //Debug.Log("Frame " + frames + " with transparancy as " + (1f-var));
        // ^^ fuck you jorge its back now
        gameObject.transform.localScale = new Vector3(var, var, 1);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - var);
        frames++;
    }
}
