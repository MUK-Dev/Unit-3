using UnityEngine;

public class RunnerGameManager : MonoBehaviour
{
    public static RunnerGameManager Instance { get; private set; }
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    public void FinishGame() => isGameOver = true;

    public bool IsGameOver() => isGameOver;
}
