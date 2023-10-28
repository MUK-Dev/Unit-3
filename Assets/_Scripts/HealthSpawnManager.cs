using UnityEngine;

public class HealthSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject money;
    [SerializeField] private float initialDelay = 2f;
    [SerializeField] private float reSpawnAfter = 15f;
    [SerializeField] private float lowerBound = -0.5f;
    [SerializeField] private float higherBound = 16.5f;

    private void Start()
    {
        InvokeRepeating("SpawnBalloon", initialDelay, reSpawnAfter);
    }

    private void SpawnBalloon()
    {
        bool isGameOver = GameManager.Instance.IsGameOver();
        if (!isGameOver)
        {
            Vector3 spawnPos = new Vector3(Random.Range(lowerBound, higherBound), 20f, 2);
            Instantiate(money, spawnPos, money.transform.rotation);
        }
    }
}
