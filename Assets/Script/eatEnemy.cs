using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatEnemy : MonoBehaviour
{
    public GameObject spawnPrefab; // Assure-toi d'attacher le prefab dans l'inspecteur
    public int maxHits = 2; // Le nombre maximum de coups avant que l'ennemi ne soit d�truit
    private int currentHits = 0; // Le nombre actuel de coups
    private UpgradeManager playerUpgradeManager; // Script de gestion des am�liorations du joueur

    void Start()
    {
        playerUpgradeManager = FindObjectOfType<UpgradeManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerObject")) // Utilise le nouveau tag pour le joueur
        {
            // Augmente le compteur de coups
            currentHits++;

            Debug.Log("Current Hits: " + currentHits);

            // Calcule le nombre maximum de coups n�cessaires en fonction des d�g�ts du joueur
            int requiredHits = Mathf.CeilToInt((float)maxHits / (1 + playerUpgradeManager.GetTotalDamage()));

            // V�rifie si le nombre maximum de coups a �t� atteint
            if (currentHits >= requiredHits)
            {
                // Si le nombre maximum de coups a �t� atteint, d�truis l'ennemi
                StartCoroutine(DelayedDestroyAndSpawn());
            }
            else
            {
                // Si le nombre maximum de coups n'a pas �t� atteint, spawn un nouvel objet
                StartCoroutine(DelayedSpawn());
            }
        }
    }

    IEnumerator DelayedSpawn()
    {
        // Attends pendant 2 � 3 secondes
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        Debug.Log("Spawning delayed piece");

        // Fais spawn du nouvel objet
        Instantiate(spawnPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator DelayedDestroyAndSpawn()
    {
        // Attends pendant 2 � 3 secondes
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        // Fais spawn du nombre correct de pi�ces avant de d�truire l'ennemi
        for (int i = 0; i < maxHits; i++)
        {
            Debug.Log("Spawning piece");
            Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        }

        // D�truit l'ennemi
        Destroy(gameObject);
    }
}
