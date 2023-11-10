using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStat : MonoBehaviour
{
    public ScoreManager ScoreManager;

    private int numOfDamage = 0;
    private int numOfInsect = 0;

    private int costOfDamage = 10;
    private int costOfInsect = 20;


    private int baseDamage = 10; // D�g�ts de base
    private UpgradeManager upgradeManager;

    private void Start()
    {
       ScoreManager = GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Coin"))
        {
            Destroy(collider2D.gameObject);
        }

    }

    public void BuyDamage()
    {
        Debug.Log("BuyDamage method called!");
        if (ScoreManager.GetBiomasse() >= costOfDamage)
        {
            Debug.Log("Achat de d�g�ts r�ussi !");
            numOfDamage++;

            // Utilise la m�thode ChangeScore pour soustraire le co�t de l'am�lioration de la biomasse
            ScoreManager.ChangeScore(-costOfDamage);
        }
        else
        {
            Debug.Log("Fonds insuffisants pour l'achat de d�g�ts.");
        }
    }

    

}
