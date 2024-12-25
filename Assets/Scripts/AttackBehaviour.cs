using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : StateMachineBehaviour
{
    public float attackDistance = 5.0f;

    private Transform player;
    private NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        agent = animator.GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.isStopped = true;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null) return;

        RotateTowardsPlayer(animator);

        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance > attackDistance)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void RotateTowardsPlayer(Animator animator)
    {
        Vector3 directionToPlayer = player.position - animator.transform.position;
        directionToPlayer.y = 0;

        if (directionToPlayer != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            animator.transform.rotation = Quaternion.Slerp(
                animator.transform.rotation,
                targetRotation,
                Time.deltaTime * 5f
            );
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent != null)
        {
            agent.isStopped = false;
        }
        animator.SetBool("isAttacking", false);
    }
}