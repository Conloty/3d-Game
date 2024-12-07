using UnityEngine;
using UnityEngine.AI;

public class WalkBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 10;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 4;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log($"Setting destination to: {player.position}");
        Debug.Log($"Agent position: {agent.transform.position}");
        Debug.Log($"Agent is on NavMesh: {agent.isOnNavMesh}");

        agent.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent?.SetDestination(agent.transform.position);
    }
}
