using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravityModifier;
    private Rigidbody rb;
    private bool isGrounded = true;
    private const string GROUND = "Ground";
    private const string OBSTACLE = "Obstacle";

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
        }
        else if (other.gameObject.CompareTag(OBSTACLE))
        {
            RunnerGameManager.Instance.FinishGame();
            Debug.Log("Game over!");
        }
    }
}
