using System;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float lowerBound = -0.5f;
    [SerializeField] private float higherBound = 16.5f;
    [SerializeField] private ParticleSystem dirtParticles;
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private Transform weapon;
    [SerializeField] private GameObject bullet;

    public event EventHandler OnHealthChange;

    [HideInInspector] public float playerHealth = 25;
    [HideInInspector] public float maxPlayerHealth = 25;

    private const string IS_MOVING = "IsMoving";
    private const string SHOOT = "Shoot";

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();

        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(SHOOT);
            GameObject shotBullet = Instantiate(bullet);
            shotBullet.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y, 2);
        }
    }

    private void Movement()
    {
        float h = Input.GetAxis("Horizontal");

        if (h != 0)
        {

            if (!dirtParticles.isPlaying)
                dirtParticles.Play();
            animator.SetBool(IS_MOVING, true);
            if (h > 0)
                transform.rotation = new Quaternion(0.00000f, 0.70708f, 0.00000f, 0.70713f);
            else if (h < 0)
                transform.rotation = new Quaternion(0.00000f, -0.70712f, 0.00000f, 0.70710f);
        }
        else
        {
            if (!dirtParticles.isStopped)
                dirtParticles.Stop();
            animator.SetBool(IS_MOVING, false);
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }

        if (transform.position.x < lowerBound)
        {
            transform.position = new Vector3(lowerBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > higherBound)
        {
            transform.position = new Vector3(higherBound, transform.position.y, transform.position.z);
        }

        if (h > 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * h);
        }
        else if (h < 0)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime * h);
        }
    }

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        bool isGameOver = GameManager.Instance.IsGameOver();
        if (!isGameOver)
        {

            if (other.gameObject.CompareTag("Obstacle"))
            {
                playerHealth--;
                OnHealthChange?.Invoke(this, EventArgs.Empty);
                if (playerHealth < 1)
                {
                    explosionParticles.Play();
                    GameManager.Instance.FinishGame();
                }
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Money"))
            {
                if (playerHealth + 5 > maxPlayerHealth)
                    playerHealth = 25;
                else
                    playerHealth += 5;
                OnHealthChange?.Invoke(this, EventArgs.Empty);
                Destroy(other.gameObject);
            }
        }
    }
}
