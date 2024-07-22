using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ScoreStorer : MonoBehaviour
{
    // Static instance of the GameManager
    public static ScoreStorer Instance { get; private set; }

    // Example public variable
    public int Score { get; set; }

    void Update()
    {
    UnityEngine.Debug.Log(Score);
    }

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Check if instance is null
        if (Instance == null)
        {
            // Set this instance as the singleton instance
            Instance = this;
            // Prevent this GameObject from being destroyed on scene load
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy this GameObject if another instance already exists
            Destroy(gameObject);
        }
    }

    // Example method to demonstrate functionality
    public void StoreScore(int amount)
    {
        Score = amount;
        
    }

    public int getScore()
    {
        return Score;
    }
}

