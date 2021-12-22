using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] highScoreTexts;
    void Start()
    {
        int[] scores = ScoresManager.Instance.GetHighScores();
        string[] names = ScoresManager.Instance.GetHighScoreNames();
        for (int i = 0 ; i< highScoreTexts.Length; i++) {
            highScoreTexts[i].text = names[i] + ": " + scores[i];
        }
    }

}
