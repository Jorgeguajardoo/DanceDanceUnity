using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectDriver : MonoBehaviour
{
    private int songIndex;
    private string[] songNameList;

    // Start is called before the first frame update
    void Start()
    {
        songNameList = new string[] {"circles","littledarkage","rulerofeverything"};
        // the above list MUST BE MANUALLY CHANGED when adding a song! idk a better way to circumvent this, maybe has something to do with finding the list of files in the songnotes folder. idk hmu with any ideas
        songIndex = 0;
        SetUp();
    }

    void SetUp()
    {
        //will cook on this later... please standby
    }
}
