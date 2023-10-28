using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        bool isGameOver = GameManager.Instance.IsGameOver();
        if (!isGameOver)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            if (other.gameObject.TryGetComponent<Balloon>(out Balloon balloon))
            {
                balloon.DestroyBalloon();
                GameManager.Instance.IncreaseScore();
            }
        }
    }
}
