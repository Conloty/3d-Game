using UnityEngine;

public class idleBehaviour : StateMachineBehaviour
{
    Transform player;
    float chaseRange = 50;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(animator.transform.position, player.position);

        animator.SetBool("isWalking", distance < chaseRange);
    }
}
