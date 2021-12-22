using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;
    public float paddleSize;

    private Diff diff;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            LoadDiff();
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
    }
    
    public void UpdatePaddleSize(float newSize) {
        Instance.paddleSize = newSize;
        SaveDiff();
    }

    void SaveDiff() {
        Instance.diff.paddleSize = Instance.paddleSize; 
        string data = JsonUtility.ToJson(Instance.diff);
        File.WriteAllText(Application.persistentDataPath + "/Difficulty.json", data);
    }

    void LoadDiff() {
        diff = new Diff();
        string path = Application.persistentDataPath + "/Difficulty.json";
        if (File.Exists(path)) {
            string data = File.ReadAllText(path);
            diff = JsonUtility.FromJson<Diff>(data);
        }    
        Instance.paddleSize = diff.paddleSize;
    }

    [System.Serializable]
    class Diff {
        public float paddleSize;
        public Diff() {
            paddleSize = 0.8f;
        }
        
    }
}
