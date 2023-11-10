using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int upgradedDamage = 0; // Dégâts améliorés
    public int coins = 0; // Monnaie du joueur

    // Paramètres spécifiques à ton jeu
    public int maxUpgradeLevel = 5; // Niveau maximum d'amélioration
    public int[] damageIncreaseByLevel = { 5, 10, 15, 20, 25 }; // Augmentation des dégâts par niveau
    public int[] upgradeCostByLevel = { 10, 20, 30, 40, 50 }; // Coût d'amélioration par niveau

    public void ApplyDamageUpgrade()
    {
        int currentUpgradeLevel = Mathf.Min(upgradedDamage, maxUpgradeLevel);
        if (currentUpgradeLevel < maxUpgradeLevel)
        {
            upgradedDamage += damageIncreaseByLevel[currentUpgradeLevel];
            coins -= upgradeCostByLevel[currentUpgradeLevel];

            Debug.Log("Upgraded damage: " + upgradedDamage);
            Debug.Log("Coins spent: " + upgradeCostByLevel[currentUpgradeLevel]);
        }
        else
        {
            Debug.Log("Maximum upgrade level reached");
        }
    }

    public void EarnCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins earned: " + amount);
    }

    public int GetTotalDamage()
    {
        return upgradedDamage;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void SpendCoins(int amount)
    {
        coins -= amount;
    }
}
