using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    private bool damageUpgradePurchased = false;
    private int damageIncreaseAmount = 10;
    private int baseDamage = 50; 
    private int damageUpgradeCost = 10; 
    private int insectCost = 30; 
    public GameObject insectPrefab;
    public TextMeshProUGUI damageUpgradePriceText;
    public TextMeshProUGUI insectPriceText;

    public static UpgradeManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateDamageUpgradePriceText();
        UpdateInsectPriceText();
    }

    public void BuyDamageUpgrade()
    {
        if (!damageUpgradePurchased)
        {
            if (ScoreManager.instance.GetBiomasse() >= damageUpgradeCost)
            {
                PlayerStat.instance.IncreaseDamage(damageIncreaseAmount);
                ScoreManager.instance.ChangeScore(-damageUpgradeCost);
                damageUpgradePurchased = true;
                Debug.Log("Augmentation de dégâts achetée !");
                IncreaseDamageUpgradeCost(); 
                UpdateDamageUpgradePriceText();
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

    public void AddInsect()
    {
        if (!damageUpgradePurchased)
        {
            if (ScoreManager.instance.GetBiomasse() >= insectCost)
            {
                ScoreManager.instance.ChangeScore(-insectCost);
                damageUpgradePurchased = true;
                Debug.Log("Add Insecte !");
                IncreaseInsectCost();
                UpdateInsectPriceText(); 

                Invoke("SpawnInsect", 2f);
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


    void SpawnInsect()
    {
        if (insectPrefab != null)
        {
            Instantiate(insectPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Le prefab de l'insecte n'est pas défini !");
        }
    }

    void IncreaseDamageUpgradeCost()
    {
        damageUpgradeCost += 10; 
    }

    void IncreaseInsectCost()
    {
        insectCost += 20; 
    }

    void UpdateDamageUpgradePriceText()
    {
        damageUpgradePriceText.text = "Prix : " + damageUpgradeCost.ToString();
    }

    void UpdateInsectPriceText()
    {
        insectPriceText.text = "Prix : " + insectCost.ToString();
    }

    public void ResetPurchaseStatus()
    {
        damageUpgradePurchased = false;
    }
}
