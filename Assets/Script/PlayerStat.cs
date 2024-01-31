using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public ScoreManager ScoreManager;
    public OpenShop openShop;

  
    private int baseDamage = 50; // Dégâts de base
    private int currentDamage; // Dégâts actuels du joueur

    private static PlayerStat _instance;

    public static PlayerStat instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerStat>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        ScoreManager = GetComponent<ScoreManager>();
        openShop = GetComponent<OpenShop>();

        // Initialise les dégâts actuels du joueur avec les dégâts de base
        currentDamage = baseDamage;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);
        }
    }

    // Ajoute cette fonction pour augmenter les dégâts du joueur
    public void IncreaseDamage(int amount)
    {
        currentDamage += amount;
    }

    // Ajoute cette fonction pour obtenir les dégâts actuels du joueur
    public int GetCurrentDamage()
    {
        return currentDamage;
    }

    // Ajoute cette fonction pour infliger des dégâts à l'ennemi
    public void InflictDamage(eatEnemy enemy)
    {
        // Ici, tu peux ajuster comment tu veux gérer l'infliger de dégâts à l'ennemi
        enemy.TakeDamage(currentDamage);
    }

    public int GetBaseDamage()
    {
        return baseDamage;
    }
}
