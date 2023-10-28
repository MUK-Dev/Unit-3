using UnityEngine;

public class BallonsSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject balloon;
    [SerializeField] private float initialDelay;
    [SerializeField] private float reSpawnAfter;
    [SerializeField] private float lowerBound = -0.5f;
    [SerializeField] private float higherBound = 16.5f;

    private int balloonCount = 1;

    private void Start()
    {
        InvokeRepeating("SpawnWave", initialDelay, reSpawnAfter);
    }

    private void SpawnWave()
    {
        bool isGameOver = GameManager.Instance.IsGameOver();
        if (!isGameOver)
        {

            for (int index = 1; index < balloonCount; index++)
            {
                SpawnBalloon();
            }
            int nextDifficulty = Random.Range(1, 3);
            balloonCount += nextDifficulty;
        }
    }

    private void SpawnBalloon()
    {
        Vector3 spawnPos = new Vector3(Random.Range(lowerBound, higherBound), 20f, 2);
        Instantiate(balloon, spawnPos, balloon.transform.rotation);
    }
}
