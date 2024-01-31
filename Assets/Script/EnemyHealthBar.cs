using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar; // Assure-toi d'avoir un objet Image associé dans l'inspecteur

    private float maxHealth = 100f; // Valeur maximale de santé de l'ennemi
    private float currentHealth = 100f; // Santé actuelle de l'ennemi

    // Appelée pour mettre à jour la barre de vie
    public void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        healthBar.fillAmount = healthPercentage;
    }

    // Appelée pour réduire la santé de l'ennemi
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            // L'ennemi est mort, ajoute ici toute logique supplémentaire
            Destroy(gameObject);
        }
    }
}
