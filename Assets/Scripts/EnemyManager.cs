using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Collider attackCollider;
    private bool canAttack = false;
    public int damageCount = 10;
    public int HP = 100;
    private void Start()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            CharacterControllerUniversal player = other.GetComponent<CharacterControllerUniversal>();
            if (player != null)
            {
                CharacterControllerUniversal.GetDamage(damageCount);
                canAttack = false;
            }
        }
    }

    public void EnableAttackCollider()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = true;
            canAttack = true;
        }
    }

    public void DisableAttackCollider()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
            canAttack = false;
        }
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            EnemySpawner.Count();
            Destroy(gameObject);
        }
        Debug.Log("Enemy health: " + HP);
    }
}