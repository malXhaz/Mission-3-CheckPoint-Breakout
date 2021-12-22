using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    [SerializeField] Button[] settingsButtons;
    void Start()
    {
        float paddleSize = DifficultyManager.Instance.paddleSize;
        if (paddleSize >= 0.39f && paddleSize <= 0.41f) {
            settingsButtons[0].Select();
        } else if (paddleSize >= 0.79f && paddleSize <= 0.81) {
            settingsButtons[1].Select();
        } else if (paddleSize == 1.59f && paddleSize <= 1.61) {
            settingsButtons[2].Select();
        }
        
    }
}
