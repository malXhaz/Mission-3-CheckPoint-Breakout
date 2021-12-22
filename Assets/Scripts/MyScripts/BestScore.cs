using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    void Start()
    {
        bestScoreText.text = "Best Score - " + ScoresManager.Instance.GetBestScore(); 
    }

    
}
