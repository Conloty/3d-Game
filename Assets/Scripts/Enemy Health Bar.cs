using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public float maxHealth;
    private EnemyManager em;
    private void Start()
    {
        em = GetComponentInParent<EnemyManager>();
        maxHealth = em.HP;
        healthSlider.value = em.HP;
        healthSlider.maxValue = maxHealth;
        UpdateHealthText();
    }

    private void Update()
    {
        healthSlider.value = em.HP;
        UpdateHealthText();
        if (healthSlider.value < 0)
        {
            healthSlider.value = 0;
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = $"{em.HP}/{maxHealth}";
    }
}
