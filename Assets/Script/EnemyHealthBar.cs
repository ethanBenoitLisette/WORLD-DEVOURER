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

        CheckIfDead();
    }

    // V�rifie si l'ennemi est mort
    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            // L'ennemi est mort, d�clenche une action ici
            EnemyDied();
        }
    }

    // Action d�clench�e lorsque l'ennemi meurt
    private void EnemyDied()
    {
        // Ici, tu peux mettre en �uvre une logique pour g�rer la mort de l'ennemi
        Destroy(gameObject);
    }
}
