using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static int bestScoreValue = 0;
    Text bestScore;

    void Start()
    {
      bestScore = GetComponent<Text>();
    }

    void Update()
    {
      if (Score.scoreValue > bestScoreValue)
      {
        bestScoreValue = Score.scoreValue;
      }
      bestScore.text = "Best Score: " + bestScoreValue;
    }

}
