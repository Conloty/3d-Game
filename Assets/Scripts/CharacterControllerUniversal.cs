using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterControllerUniversal : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] GameObject mainCam;
    [SerializeField] Transform cameraFollowTarget;
    Animator animator;

    public static float health;
    public static bool gameOver;
    private bool isAttacking = false;

    private PlayerInputsManager input;
    private Rigidbody rb;
    float xRotation;
    float yRotation;

    private void Start()
    {
        input = GetComponent<PlayerInputsManager>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        
        health = 10000f;
        gameOver = false;

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        } else
        {
            animator.SetBool("isRunning", false);
        }
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isAttacking", true);
            animator.SetBool("isRunning", false);
            isAttacking = true;
        }

        if (gameOver)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void OnAttackAnimationEnd()
    {
        animator.SetBool("isAttacking", false);
        isAttacking = false;
    }

    public void OnAttackAnimationStart()
    {
        animator.SetBool("isRunning", false);
    }

    void MoveCharacter()
    {
        if (!isAttacking)
        {
            Vector3 inputDir = new Vector3(input.move.x, 0, input.move.y);
            if (inputDir != Vector3.zero)
            {
                float targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0, targetRotation, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

                Vector3 targetDirection = rotation * Vector3.forward;
                Vector3 velocity = targetDirection * moveSpeed;
                rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
            }
        }
    }

    void CameraRotation()
    {
        xRotation += input.look.y;
        yRotation += input.look.x;

        xRotation = Mathf.Clamp(xRotation, -30, 70);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        cameraFollowTarget.rotation = rotation;
    }

    public static void Damage(int damageCount)
    {
        health -= damageCount;
        Debug.Log("current health: " + health);
        if(health <= 0)
        {
            gameOver = true;
        }
    }
}

