using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biomasse : MonoBehaviour
{
    public int biomasseValue = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("PlayerObject"))
        {
            ScoreManager.instance.ChangeScore(biomasseValue);

            StartCoroutine(DisableAfterDelay());
        }
    }

    IEnumerator DisableAfterDelay()
    {
        // Attends pendant un court délai (ajuste si nécessaire avant de désactiver l'objet)
        yield return new WaitForSeconds(0.1f);

        // Désactive la pièce après le délai
        gameObject.SetActive(false);
        StartCoroutine(ReactivateAfterDelay());
    }

    IEnumerator ReactivateAfterDelay()
    {
        // Attends pendant un certain délai (ajuste si nécessaire avant de réactiver l'objet)
        yield return new WaitForSeconds(2f);

        // Réactive la pièce après le délai
        gameObject.SetActive(true);
    }
}
