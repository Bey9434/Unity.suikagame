using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score { get; private set; }
    public delegate void ScoreUpdated(int newScore);
    public static event ScoreUpdated OnScoreUpdated;

    public static void AddScore(int amount)
    {
        Score += amount;
        OnScoreUpdated?.Invoke(Score);
    }
    
}

