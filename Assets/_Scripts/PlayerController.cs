using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravityModifier;
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private ParticleSystem dirtParticles;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

    private const string GROUND = "Ground";
    private const string OBSTACLE = "Obstacle";
    private const string JUMP_TRIGGER = "Jump_trig";
    private const string DEATH_TYPE_INT = "DeathType_int";
    private const string DEATH_B = "Death_b";
    private const string GROUNDED = "Grounded";

    private Rigidbody rb;
    private Animator animator;
    private new AudioSource audio;
    private bool isGrounded = true;

    private int jumpCount = 0;

    private float initialMoveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        bool isGameOver = RunnerGameManager.Instance.IsGameOver();
        bool isGameStarted = RunnerGameManager.Instance.IsGameStarted();

        BeforeGameStarted(isGameStarted);

        DuringGameplay(isGameStarted, isGameOver);
    }

    private void BeforeGameStarted(bool isGameStarted)
    {
        if (!isGameStarted)
        {
            transform.Translate(Vector3.forward * initialMoveSpeed * Time.deltaTime);

            if (transform.position.x > 2)
            {
                RunnerGameManager.Instance.StartGame();
            }
        }
    }

    private void DuringGameplay(bool isGameStarted, bool isGameOver)
    {
        if (isGameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !isGameOver)
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                jumpCount++;
                isGrounded = false;
                animator.SetTrigger(JUMP_TRIGGER);
                dirtParticles.Stop();
                audio.PlayOneShot(jumpSound, 1f);
            }
            // animator.SetBool(GROUNDED, isGrounded);

            if (Input.GetKey(KeyCode.D))
            {
                Time.timeScale = 1.5f;
                Time.fixedDeltaTime = 0.03f;
            }
            else
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = 0.02f;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
            jumpCount = 0;
            dirtParticles.Play();
        }
        else if (other.gameObject.CompareTag(OBSTACLE))
        {
            audio.PlayOneShot(crashSound, 1f);
            RunnerGameManager.Instance.FinishGame();
            animator.SetBool(DEATH_B, true);
            animator.SetInteger(DEATH_TYPE_INT, 1);
            dirtParticles.Stop();
            explosionParticles.Play();
        }
    }
}
