using UnityEngine;

public class PController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * v);
        transform.Translate(Vector3.right * speed * Time.deltaTime * h);
    }
}
