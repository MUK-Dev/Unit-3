using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float initialDelay = 1f;
    [SerializeField] private float reSpawnAfter = 2f;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", initialDelay, reSpawnAfter);
    }
    private void SpawnObstacle()
    {
        if (!RunnerGameManager.Instance.IsGameOver())
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
