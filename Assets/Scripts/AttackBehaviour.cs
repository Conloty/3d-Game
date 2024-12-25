using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : StateMachineBehaviour
{
    public int damageCount = 150;
    public float attackCooldown = 2.0f;
    public float attackDistance = 5.0f;

    private Transform player;
    private NavMeshAgent agent;
    private Collider attackCollider;

    private bool canAttack = true;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        agent = animator.GetComponent<NavMeshAgent>();
        attackCollider = animator.transform.Find("Арматура/Ik11.L/DamageItem")?.GetComponent<Collider>();

        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }

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
        else if (canAttack)
        {
            canAttack = false;
            animator.SetTrigger("Attack");
            var manager = animator.GetComponentInParent<EnemyManager>();
            if (manager != null)
            {
                manager.EnableAttackCollider();
            }
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
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }

        if (agent != null)
        {
            agent.isStopped = false;
        }

        animator.ResetTrigger("Attack");
    }
}