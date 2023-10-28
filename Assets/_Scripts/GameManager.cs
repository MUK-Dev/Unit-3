using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int score;

    public event EventHandler OnScoreChange;
    public event EventHandler OnGameOver;

    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
    }

    public int GetScore() => score;

    public void IncreaseScore()
    {
        score++;
        OnScoreChange?.Invoke(this, EventArgs.Empty);
    }

    public void FinishGame()
    {
        isGameOver = true;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }

    public bool IsGameOver() => isGameOver;
}
