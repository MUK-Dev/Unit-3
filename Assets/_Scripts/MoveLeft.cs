using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float leftBound = -10f;
    private const string OBSTACLE = "Obstacle";

    private void Update()
    {
        if (!RunnerGameManager.Instance.IsGameOver())
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag(OBSTACLE))
        {
            Destroy(gameObject);
        }
    }
}
