using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    TMP_Text scoreText;

    int score;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }

    public void IncreaseScore(int aomuntToIncrease)
    {
        score += aomuntToIncrease;
        scoreText.text = score.ToString();
    }

}
