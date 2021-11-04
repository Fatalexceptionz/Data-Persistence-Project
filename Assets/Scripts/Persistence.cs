using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static Persistence Instance;
    
    
    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    private const string fileName = "/scores.json";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        LoadScore();
    }

    class SaveData
    {
        public string PlayerName;
        public int Score;
    }

    public void SaveScore()
    {
        var data = new SaveData();

        data.PlayerName = highScorePlayerName;
        data.Score = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + fileName, json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + fileName;

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.PlayerName;
            highScore = data.Score;
        }
    }
}
