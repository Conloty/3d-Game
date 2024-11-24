using Unity.VisualScripting;
using UnityEngine;

public class CharacterControllerUniversal : MonoBehaviour
{
    [SerializeField] float Movespeed = 8f;

    private PlayerInputsManager input;
    private CharacterController controller;

    [SerializeField] GameObject mainCam;
    [SerializeField] Transform cameraFollowTarget;
    float xRotation;
    float yRotation;
    
    private void Start()
    {
        input = GetComponent<PlayerInputsManager>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float speed = 0f;
        Vector3 inputDir = new Vector3(input.move.x, 0, input.move.y);
        float targetRotation = 0;
        if(input.move != Vector2.zero) 
        {
            speed = Movespeed;
            targetRotation = Quaternion.LookRotation(inputDir).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetRotation, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
        Vector3 targetDirection = Quaternion.Euler(0, targetRotation, 0) * Vector3.forward;
        controller.Move(targetDirection * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        CameraRotation();

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

