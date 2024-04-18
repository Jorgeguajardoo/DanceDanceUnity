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
        var = .01f;
        frames = 0;
        //gameObject.transform.localScale = new Vector3(var, var, 1);
        //gameObject.getComponent<SpriteRender>().color = new Color(1f, 1f, 1f, 1f-var);
    }

    // Update is called once per frame
    void Update()
    {
        if(frames >= 20)
        {
            Destroy(gameObject);
        }
        // var = Math.Sqrt(var);
        // ^^ I COMMENTED THIS OUT SO IT WOULD COMPILE TO TEST OTHER STUFF SRY DEVIN
        //gameObject.transform.localScale = new Vector3(var, var, 1);
        //gameObject.SpriteRender.color = new Color(1f, 1f, 1f, 1f - var);
    }
}
