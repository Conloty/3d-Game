using UnityEngine;

public class CharacterControllerUniversal : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] GameObject mainCam;
    [SerializeField] Transform cameraFollowTarget;

    private PlayerInputsManager input;
    private Rigidbody rb;
    float xRotation;
    float yRotation;

    private void Start()
    {
        input = GetComponent<PlayerInputsManager>();
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    void MoveCharacter()
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

    void CameraRotation()
    {
        xRotation += input.look.y;
        yRotation += input.look.x;

        xRotation = Mathf.Clamp(xRotation, -30, 70);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        cameraFollowTarget.rotation = rotation;
    }
}

