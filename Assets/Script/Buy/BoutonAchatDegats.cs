using UnityEngine;
using UnityEngine.UI;

public class BoutonAchatDegats : MonoBehaviour
{

    // Fonction appel�e lors du clic sur le bouton d'achat de d�g�ts
    public void AcheterDegats()
    {
        // Appelle la fonction d'achat de d�g�ts du UpgradeManager
        UpgradeManager.instance.BuyDamageUpgrade();
    }
}
