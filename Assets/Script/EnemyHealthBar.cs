using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar; // Assure-toi d'avoir un objet Image associ� dans l'inspecteur

    private float maxHealth = 100f; // Valeur maximale de sant� de l'ennemi
    private float currentHealth = 100f; // Sant� actuelle de l'ennemi

    // Appel�e pour mettre � jour la barre de vie
    public void UpdateHealthBar()
    {
        float healthPercentage = currentHealth / maxHealth;
        healthBar.fillAmount = healthPercentage;
    }

    // Appel�e pour r�duire la sant� de l'ennemi
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            // L'ennemi est mort, ajoute ici toute logique suppl�mentaire
            Destroy(gameObject);
        }
    }
}
