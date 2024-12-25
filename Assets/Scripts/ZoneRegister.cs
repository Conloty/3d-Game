using UnityEngine;

public class ZoneRegister : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && EnemySpawner.startRound)
        {
            EnemySpawner es = GetComponent<EnemySpawner>();
            Debug.Log("Player in zone");
            es.SpawnEnemies();
            EnemySpawner.startRound = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && EnemySpawner.startRound)
        {
            EnemySpawner es = GetComponent<EnemySpawner>();
            Debug.Log("Player still in zone");
            es.SpawnEnemies();
            EnemySpawner.startRound = false;
        }
    }
}
