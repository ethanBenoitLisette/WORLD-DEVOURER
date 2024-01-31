using UnityEngine;
using UnityEngine.UI;

public class BoutonAchatDegats : MonoBehaviour
{

    // Fonction appelée lors du clic sur le bouton d'achat de dégâts
    public void AcheterDegats()
    {
        // Appelle la fonction d'achat de dégâts du UpgradeManager
        UpgradeManager.instance.BuyDamageUpgrade();
    }
}
