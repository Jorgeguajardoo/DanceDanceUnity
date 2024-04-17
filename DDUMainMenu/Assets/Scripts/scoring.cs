using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoring : MonoBehaviour
{
    public int score;
    private TextMeshPro scoredisplay;
    // Start is called before the first frame update
    void Start()
    {
        scoredisplay = GetComponent<TextMeshPro>();
        score = 0;
        scoredisplay.SetText(score.ToString("D6"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate(int points)
    {
        score += points;
        scoredisplay.SetText(score.ToString("D6"));
    }
}
