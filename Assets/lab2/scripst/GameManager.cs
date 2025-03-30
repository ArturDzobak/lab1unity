using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int lives = 3;
    public int collisions = 0;
    public int coinsCollected = 0;
    public float timeElapsed = 0f;
    public float highScore = 0f; 
    public float timeLimit = 20f;
    public float bestScore = 0f;

    private string savePath;

    public event Action OnGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Path.Combine(Application.dataPath, "save.json"); 
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeLimit)
        {
            TriggerGameOver();
        }
    }

    public void CollectCoin()
    {
        coinsCollected++;
    }

    public void QuantityOfCollision()
    {
        collisions++;
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
        Debug.Log("Гра закінчена!");
        SaveData();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void SaveData()
    {
        highScore = coinsCollected * 25 - timeElapsed * 1;

        GameData data = new GameData
        {
            lives = this.lives,
            collisions = this.collisions,
            coinsCollected = this.coinsCollected,
            timeElapsed = this.timeElapsed,
            highScore = this.highScore,
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        List<GameData> allData = new List<GameData>();

        
        if (File.Exists(savePath))
        {
            string existingData = File.ReadAllText(savePath);
            try
            {             
                allData = JsonConvert.DeserializeObject<List<GameData>>(existingData) ?? new List<GameData>();
            }
            catch (JsonReaderException)
            {
                allData = new List<GameData>();
            }
        }

        allData.Add(data);

        string jsonData = JsonConvert.SerializeObject(allData, Formatting.Indented);
        File.WriteAllText(savePath, jsonData); 
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string jsonData = File.ReadAllText(savePath);
            try
            {
                List<GameData> data = JsonConvert.DeserializeObject<List<GameData>>(jsonData);

                if (data != null && data.Count > 0)
                {
                    bestScore = 0f; 
                    foreach (var gameData in data)
                    {
                        if (gameData.highScore > bestScore)
                        {
                            bestScore = gameData.highScore;
                        }
                    }

                    
                    //var latestGame = data[data.Count - 1];
                   
                    //this.lives = latestGame.lives;
                    //this.collisions = latestGame.collisions;
                    //this.coinsCollected = latestGame.coinsCollected;
                    //this.timeElapsed = latestGame.timeElapsed;
                }
            }
            catch (JsonSerializationException e)
            {
                Debug.LogError($"Помилка при десеріалізації JSON: {e.Message}");
            }
        }
    }

}


[Serializable]
public class GameData
{
    public int lives;
    public int collisions;
    public int coinsCollected;
    public float timeElapsed;
    public string timestamp;
    public float highScore;
}

