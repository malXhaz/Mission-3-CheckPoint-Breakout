using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void UpdatePlayerName() {
        ScoresManager.Instance.playerName = nameInput.text;
    }
}
