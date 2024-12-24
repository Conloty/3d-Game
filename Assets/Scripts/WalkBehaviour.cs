using UnityEngine;
using UnityEngine.AI;

public class WalkBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float attackRange = 5;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if(distance < attackRange) animator.SetBool("isAttacking", true);
        
        if(distance > 5) animator.SetBool("isWalking", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.ResetPath();
    }
}
