using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private bool damageUpgradePurchased = false;
    private int damageIncreaseAmount = 10;
    private int baseDamage = 50; // D�g�ts de base

    // Ajoute cette ligne pour d�clarer l'instance
    public static UpgradeManager instance;

    private void Awake()
    {
        // Assure-toi que l'instance est assign�e lors de l'�veil du script
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

                Debug.Log("Augmentation de d�g�ts achet�e !");
            }
            else
            {
                Debug.Log("Fonds insuffisants pour l'achat de l'augmentation de d�g�ts.");
            }
        }
        else
        {
            Debug.Log("L'augmentation de d�g�ts a d�j� �t� achet�e.");
        }
    }

    // Fonction pour r�cup�rer les d�g�ts de base
    public int GetBaseDamage()
    {
        return baseDamage;
    }

}
