using TMPro;
using UnityEngine;
public class Counter : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    private void Update()
    {
        if (tmp != null)
        {
            tmp.text = $"Score: {EnemySpawner.totalCountOfDefeatedEnemies}";
        }
    }
}
