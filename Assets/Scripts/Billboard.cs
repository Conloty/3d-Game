using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    public void Start()
    {
        cam = Camera.main.transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
