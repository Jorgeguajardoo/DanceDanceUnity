using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteScript : MonoBehaviour
{
    public GameObject scoredisplay, player;
    public float notespeed, positionX;
    public float yspeed = 0; 
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(positionX, 4.5F, 0.0F);
        notespeed *= 0.00001F;
        scoredisplay = GameObject.Find("Score Display");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(notespeed >= 1)
        {
            return;
        }
        yspeed -= notespeed;
        gameObject.transform.position = new Vector3(positionX, gameObject.transform.position.y + yspeed, 0.0F);
    }

    void FixedUpdate()
    {
        if (gameObject.transform.position.y <= -4.18)
        {
            Debug.Log("Note hit detected");
            float offset = positionX - player.transform.position.x;
            gameObject.SetActive(false);
            if(offset < 0)
            {
                offset *= -1;
            }
            int points = 100 - (int)(offset * 50);
            scoredisplay.GetComponent<scoring>().ScoreUpdate(points);
            Debug.Log("note hit and deleted, logged for " + points + " points");
        }
    }
}
