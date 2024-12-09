using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) animator.SetBool("isAttack", true);
        else if (Input.GetButtonUp("Fire1")) animator.SetBool("isAttack", false);
    }
}
