using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Collider attackCollider;
    
    public int damageCount = 150;
    public int HP = 100;
    public bool canAttack = false;

    private void Start()
    {

        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in trigger canAttack " + canAttack);
        if (other.CompareTag("Player") && canAttack)
        {
            Debug.Log("inside tigger");
            CharacterControllerUniversal.GetDamage(damageCount);
            canAttack = false;
        }
    }

    public void AttackStart()
    {
        canAttack = true;
        attackCollider.enabled = true;
    }

    public void AttackEnd()
    {
        canAttack = false;
        attackCollider.enabled = false;
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