using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public float maxHealth = 1200f;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = CharacterControllerUniversal.health;

        UpdateHealthText();
    }

    private void Update()
    {
        healthSlider.value = CharacterControllerUniversal.health;

        UpdateHealthText();

        if (healthSlider.value < 0)
        {
            healthSlider.value = 0;
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = $"{CharacterControllerUniversal.health}/{maxHealth}";
    }
}
