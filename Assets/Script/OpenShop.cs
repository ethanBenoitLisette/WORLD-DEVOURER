using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject Shop;
    public PlayerStat playerStat; // Ajoute cette ligne

    void Start()
    {
        Shop.SetActive(false);
    }

    public void ToggleShop()
    {
        Shop.SetActive(!Shop.activeSelf);
    }

    public void ExitShop()
    {
        // Réinitialiser l'état d'achat lorsque le joueur quitte le magasin
        UpgradeManager.instance.ResetPurchaseStatus();
        // Fermer le magasin
        Shop.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerObject")
        {
            ToggleShop();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerObject")
        {
            ExitShop();
        }
    }
}