using UnityEngine;

public class RunnerGameManager : MonoBehaviour
{
    public static RunnerGameManager Instance { get; private set; }
    private bool isGameOver = false;
    private bool isGameStarting = true;

    private void Awake()
    {
        Instance = this;
    }

    public void FinishGame() => isGameOver = true;

    public bool IsGameOver() => isGameOver;

    public void StartGame() => isGameStarting = false;

    public bool IsGameStarted() => !isGameStarting;
}
