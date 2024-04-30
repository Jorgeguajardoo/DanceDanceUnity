using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteScript : MonoBehaviour
{
    public GameObject scoredisplay, player;
    public float notespeed, positionX;
    public float yspeed = 0;
    private int frame;
    public GameObject perfectanim, greatanim, okayanim, missanim;
    // Start is called before the first frame update
    void Start()
    {
        positionX = gameObject.transform.position.x;
        frame = 0;
        gameObject.transform.position = new Vector3(positionX, 4.55F, 0.0F);
                              // IMPORTANT: THERE IS A SQUARE ROOT RELATIONSHIP BETWEEN NOTESPEED AND FRAMES IT TAKES TO FALL (5 notespeed takes sqrt 2 longer to fall than 10 notespeed)
                              // This may seem like a joke, but it may or may not take 420 frames for a note to fall once it spawns. lmaooooooooooo
        scoredisplay = GameObject.Find("Score Display");
        player = GameObject.Find("Player");
        notespeed = GameObject.Find("AudioPlayer").GetComponent<testDriver>().notespeed;
        //Debug.Log(notespeed.ToString());
        notespeed *= 0.0001F;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //if (notespeed >= 1)
        //{
        //    return;
        //}
        yspeed -= notespeed;
        gameObject.transform.position = new Vector3(positionX, gameObject.transform.position.y + yspeed, 0.0F);
        frame++;
    }

    void LateUpdate() {
        if (gameObject.transform.position.y <= -4.25)
        {
            //Debug.Log("Note hit detected");
            //Debug.Log("NOTE HIT ON FRAME " + frame);
            float offset = positionX - player.transform.position.x;
            gameObject.SetActive(false);
            if(offset < 0)
            {
                offset *= -1;
            }
            if(offset > 1.25) //counts as miss
            {
                offset = 2.01f;
                //Debug.LogWarning("note miss!");
            }
            else
            {
                offset -= .25f;
                if(offset < 0)
                {
                    offset = 0;
                }
            }
            int points = 100 - (int)(offset * 50);
            scoredisplay.GetComponent<scoring>().ScoreUpdate(points);
            //Debug.Log("note hit and deleted, logged for " + points + " points");
            if(points == 100)
            {
                Instantiate(perfectanim, new Vector3(this.positionX, -4.5F, 0), Quaternion.identity);
            }else if(points > 70)
            {
                Instantiate(greatanim, new Vector3(this.positionX, -4.5F, 0), Quaternion.identity);
            }else if(points > 0)
            {
                Instantiate(okayanim, new Vector3(this.positionX, -4.5F, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(missanim, new Vector3(this.positionX, -4.5F, 0), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
