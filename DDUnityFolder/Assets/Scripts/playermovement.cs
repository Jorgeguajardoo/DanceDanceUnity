using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public GameObject player;
    public int movedirection = 0;
    public string leftKey = "a", rightKey = "d";
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movedirection = 0;
        if (Input.GetKey("a"))
        {
            movedirection = -1;
        }
        if (Input.GetKey("d"))
        {
            movedirection += 1;
        }
        if (movedirection!=0 && Input.GetKey("space"))
        {
            movedirection *= 2;
        }
        float positionX = player.transform.position.x + movedirection * speed;
        if (positionX < -8)
        {
            positionX = -8F;
        }
        else if (positionX > 8)
        {
            positionX = 8F;
        }
        player.transform.position = new Vector3(positionX, -4.5F, 0.0F);
    }

    void LateUpdate()
    {
        
    }
}
