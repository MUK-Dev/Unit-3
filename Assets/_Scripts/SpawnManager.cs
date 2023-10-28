using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float initialDelay = 1f;
    [SerializeField] private float reSpawnAfter = 2f;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", initialDelay, reSpawnAfter);
    }
    private void SpawnObstacle()
    {
        bool isGameOver = RunnerGameManager.Instance.IsGameOver();
        bool isGameStarted = RunnerGameManager.Instance.IsGameStarted();
        if (!isGameOver && isGameStarted)
        {
            GameObject randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(randomObstacle, spawnPosition, randomObstacle.transform.rotation);
        }
    }
}
