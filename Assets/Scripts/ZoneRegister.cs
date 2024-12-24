using UnityEngine;

public class ZoneRegister : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player in zone");
            EnemySpawner es = GetComponent<EnemySpawner>();
            es.SpawnEnemies();
        }
    }
}
