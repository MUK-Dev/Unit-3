using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float leftBound = -10f;
    private const string OBSTACLE = "Obstacle";

    private void Update()
    {
        bool isGameOver = RunnerGameManager.Instance.IsGameOver();
        bool isGameStarted = RunnerGameManager.Instance.IsGameStarted();
        if (!isGameOver && isGameStarted)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag(OBSTACLE))
        {
            Destroy(gameObject);
        }
    }
}
