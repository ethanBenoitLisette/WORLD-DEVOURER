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
        // Attends pendant un court d�lai (ajuste si n�cessaire avant de d�sactiver l'objet)
        yield return new WaitForSeconds(0.1f);

        // D�sactive la pi�ce apr�s le d�lai
        gameObject.SetActive(false);
        StartCoroutine(ReactivateAfterDelay());
    }

    IEnumerator ReactivateAfterDelay()
    {
        // Attends pendant un certain d�lai (ajuste si n�cessaire avant de r�activer l'objet)
        yield return new WaitForSeconds(2f);

        // R�active la pi�ce apr�s le d�lai
        gameObject.SetActive(true);
    }
}
