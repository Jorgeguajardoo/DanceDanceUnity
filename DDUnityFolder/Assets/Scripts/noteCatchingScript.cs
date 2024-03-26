using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteCatchingScript : MonoBehaviour
{
    private GameObject player;
    private GameObject scoredisplay;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        scoredisplay = GameObject.Find("Score Display");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
