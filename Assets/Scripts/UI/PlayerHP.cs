using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Image playerHP;

    private void Start()
    {
        healthSystem.OnDamage += ChangeHealth;
        healthSystem.OnDeath += ChangeHealthOnDeath;
    }

    private void ChangeHealth(float currentHealth)
    {
        playerHP.fillAmount = currentHealth / healthSystem.MaxHealth;
        AudioManager.instance.PlaySFX("PlayerHitSFX");
    }

    private void ChangeHealthOnDeath()
    {
        playerHP.fillAmount = 0f;
        AudioManager.instance.PlaySFX("PlayerDeathSFX");
    }
}