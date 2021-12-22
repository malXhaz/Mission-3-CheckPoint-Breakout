using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class ScoresManager : MonoBehaviour
{
    public static ScoresManager Instance;
    public string playerName;
    public int score;
    private BestScore playerScores;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            LoadScores();
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
    }

    public string GetBestScore() {
        return playerScores.playerNames[4] + ": " + playerScores.scores[4];
    }

    public int[] GetHighScores() {
        return playerScores.scores;
    }

    public string[] GetHighScoreNames () {
        return playerScores.playerNames;
    }

    public void LoadGameScene() {
        SceneManager.LoadScene(1);
    }

    public void LoadHighScoresScene() {
        SceneManager.LoadScene(2);
    }

    public void LoadMenuScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadSettingsScene() {
        SceneManager.LoadScene(3);
    }

    public void Quit() {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    public void SaveScores() {
        playerScores.CheckNewScore();
        string data = JsonUtility.ToJson(playerScores);
        File.WriteAllText(Application.persistentDataPath + "/HighScores.json", data);
    }

    public void LoadScores() {
        playerScores = new BestScore();
        string path = Application.persistentDataPath + "/HighScores.json";
        if (File.Exists(path)) {
            string data = File.ReadAllText(path);
            playerScores = JsonUtility.FromJson<BestScore>(data);
        }    
    }

    [System.Serializable]
    class BestScore {
        public string[] playerNames;
        public int[] scores;

        public BestScore() {
            playerNames = new string[5];
            scores = new int[5];
            for (int i = 0; i < scores.Length; i++){
                scores[i] = 0;
                playerNames[i] = "None: ";
            }
        }
        public void CheckNewScore() {
            if (ScoresManager.Instance.score > scores[0]) {
                scores[0] = ScoresManager.Instance.score;
                playerNames[0] = ScoresManager.Instance.playerName;
                SortScores();
            }

        }

        private void SortScores() {
            for (int i = 0; i < scores.Length - 1; i++) {
                if (scores[i] > scores[i+1]) {
                    int tmpScore = scores[i+1];
                    string tmpName = playerNames[i+1];
                    scores[i + 1] = scores[i];
                    playerNames[i+1] = playerNames[i];
                    scores[i] = tmpScore;
                    playerNames[i] = tmpName;
                }
            }
        }
    }

}
