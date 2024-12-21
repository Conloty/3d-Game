using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Collider attackCollider;
    public int damageCount = 150;

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
                CharacterControllerUniversal.Damage(damageCount);
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

    public void StartEnemyCoroutine(System.Collections.IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}

