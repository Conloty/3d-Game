using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int countEnemies = 3;
    public static int countOfDefeatedEnemies = 0;
    public static int totalCountOfDefeatedEnemies = 0;
    public static bool startRound = true;

    public Vector3[] spawnPos = {
        new Vector3(-2.75f, 1f, -52.36f),
        new Vector3(15.45f, 1f, -44.58f),
        new Vector3(28.23f, 1.05f, -60.92f),
        new Vector3(17.8f, 1f, -78.9f),
        new Vector3(5.7f, 1f, -88.18f),
        new Vector3(-11.18f, 1.05f, -69.3f)
    };
    
    public void SpawnEnemies()
    {
        for (int i = 0; i < countEnemies; i++)
        {
            Vector3 randomPos = spawnPos[Random.Range(0, spawnPos.Length)];

            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        }
        startRound = false;
    }

    //для вида позиций спавна
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 pos in spawnPos)
        {
            Gizmos.DrawSphere(pos, 0.5f);
        }
    }

    public static void Count()
    {
        countOfDefeatedEnemies++;
        totalCountOfDefeatedEnemies++;
        Debug.Log("Defeated enemies: " + totalCountOfDefeatedEnemies);
        if(countOfDefeatedEnemies == 3)
        {
            countOfDefeatedEnemies = 0;
            startRound = true;
        }
    }
}
