using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Collider attackCollider;
    public int damageCount = 10;
    public float HP = 100f;
    private void Start()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterControllerUniversal player = other.GetComponent<CharacterControllerUniversal>();
            if (player != null)
            {
                CharacterControllerUniversal.GetDamage(damageCount);
            }
        }
    }

    public void EnableAttackCollider()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = true;
        }
    }

    public void DisableAttackCollider()
    {
        if (attackCollider != null)
        {
            attackCollider.enabled = false;
        }
    }
    /*
    public void StartEnemyCoroutine(System.Collections.IEnumerator routine)
    {
        StartCoroutine(routine);
    }
    //
    public void EnableAttackColliderForDuration(float duration)
    {
        StartCoroutine(EnableColliderTemporarily(duration));
    }

    private System.Collections.IEnumerator EnableColliderTemporarily(float duration)
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(duration);
        attackCollider.enabled = false;
    }*/

    public void GetDamage(int damage)
    {
        HP -= damage;
        Debug.Log("Enemy health: " + HP);
    }
}