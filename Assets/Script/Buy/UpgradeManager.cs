using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private bool damageUpgradePurchased = false;
    private int damageIncreaseAmount = 10;
    private int baseDamage = 50; // Dégâts de base

    // Ajoute cette ligne pour déclarer l'instance
    public static UpgradeManager instance;

    private void Awake()
    {
        // Assure-toi que l'instance est assignée lors de l'éveil du script
        instance = this;
    }
    public void BuyDamageUpgrade()
    {
        if (!damageUpgradePurchased)
        {

            if (ScoreManager.instance.GetBiomasse() >= 10)
            {

                PlayerStat.instance.IncreaseDamage(damageIncreaseAmount);

  
                ScoreManager.instance.ChangeScore(-10);

 
                damageUpgradePurchased = true;

                Debug.Log("Augmentation de dégâts achetée !");
            }
            else
            {
                Debug.Log("Fonds insuffisants pour l'achat de l'augmentation de dégâts.");
            }
        }
        else
        {
            Debug.Log("L'augmentation de dégâts a déjà été achetée.");
        }
    }

    // Fonction pour récupérer les dégâts de base
    public int GetBaseDamage()
    {
        return baseDamage;
    }

}
