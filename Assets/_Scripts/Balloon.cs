using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private float forceFactor = 10;

    [SerializeField] private float horizontalForce = 1;
    [SerializeField] private AudioClip blipSound;
    private Rigidbody rb;

    [HideInInspector] public bool isChild = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.y < 0.5f)
        {
            Vector3 forceDirection = new Vector3(Random.Range(-horizontalForce, horizontalForce), 1, 0);
            rb.AddForce(forceDirection * forceFactor, ForceMode.Impulse);
        }
    }

    public void DestroyBalloon()
    {
        bool isGameOver = GameManager.Instance.IsGameOver();
        if (!isGameOver)
        {
            int noOfChildren = Random.Range(2, 4);
            if (isChild)
            {
                Destroy(gameObject);
            }
            else
            {
                for (int index = 1; index <= noOfChildren; index++)
                {
                    GameObject childBalloon = Instantiate(gameObject);
                    childBalloon.transform.position = new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1), transform.position.z);
                    childBalloon.transform.localScale = childBalloon.transform.localScale / 2;
                    Balloon balloonProperties = childBalloon.GetComponent<Balloon>();
                    balloonProperties.isChild = true;
                }
                Destroy(gameObject);
            }
        }
    }
}
