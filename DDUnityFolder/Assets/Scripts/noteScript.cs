using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteScript : MonoBehaviour
{
    public GameObject scoredisplay;
    public GameObject note;
    public float notespeed, positionX;
    public float yspeed = 0; 
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(positionX, 4.5F, 0.0F);
        notespeed *= 0.00001F;
    }

    // Update is called once per frame
    void Update()
    {
        if(notespeed >= 1)
        {
            return;
        }
        yspeed -= notespeed;
        this.transform.position = new Vector3(positionX, this.transform.position.y + yspeed, 0.0F);
    }

    void OnCollisionEnter2D(Collision2D c) 
    {
        float offset = c.gameObject.transform.position.x - positionX;
        if (offset < 0)
        {
            offset *= -1;
        }
        int points = 100 - (int)(offset * 50);
        // scoredisplay.GetComponent<scoring>().ScoreUpdate(points);
        Debug.Log("note hit: " + points + " points");
        note.SetActive(false);
        Debug.Log("note deleted");
    }
}
