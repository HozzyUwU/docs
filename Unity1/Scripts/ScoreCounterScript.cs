using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterScript : MonoBehaviour
{
    Text ScoreUI;
    string Txt = "SCORE: ";
    int ScoreCount = 0;
    
    void Start() 
    {
        ScoreUI = GetComponent<Text>();
    }

    void Update()
    {
        ScoreUI.text = Txt+ScoreCount;
    }

    public void IncreaseScore(int numb)
    {
        ScoreCount += numb;
    }
}
