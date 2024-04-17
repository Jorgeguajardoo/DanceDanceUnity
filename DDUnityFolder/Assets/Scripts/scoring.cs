using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoring : MonoBehaviour
{
    public int score;
    private TextMeshPro scoredisplay, combodisplay;
    private int combo;
    private float accuracymax, accuracymin;
    // Start is called before the first frame update
    void Start()
    {
        scoredisplay = GameObject.Find("Score Display").GetComponent<TextMeshPro>();
        combodisplay = GameObject.Find("Combo Display").GetComponent<TextMeshPro>();
        score = 0;
        combo = 0;
        Debug.Log("score reset");
        scoredisplay.SetText(score.ToString("D7"));
        accuracymax = 0;
        accuracymin = 0; 
        combodisplay.SetText("Combo " + combo.ToString("D4") + "\nAcc   " + accuracymax.ToString("00.00"));
    }

    // Update is called once per frame
    void Update()
    {
        //go fuck yourself
    }

    public void ScoreUpdate(int points)
    {
        if (points == 0)
        {
            combo = 0;
        }
        accuracymin += points;
        accuracymax += 100;
        if (combo >= 40)
        {
            points *= 5;
        }
        else
        {
            points = (int)(points * (combo + 10) / 10);
        }
        score += points;
        scoredisplay.SetText(score.ToString("D7"));
        combo++;
        combodisplay.SetText("Combo " + combo.ToString("D4") + "\nAcc   " + (accuracymin * 100 / accuracymax).ToString("00.00"));
    }
}
