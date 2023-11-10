using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatEnemy : MonoBehaviour
{
    public GameObject spawnPrefab; // Assure-toi d'attacher le prefab dans l'inspecteur
    public int maxHits = 2; // Le nombre maximum de coups avant que l'ennemi ne soit détruit
    private int currentHits = 0; // Le nombre actuel de coups
    private UpgradeManager playerUpgradeManager; // Script de gestion des améliorations du joueur

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

            // Calcule le nombre maximum de coups nécessaires en fonction des dégâts du joueur
            int requiredHits = Mathf.CeilToInt((float)maxHits / (1 + playerUpgradeManager.GetTotalDamage()));

            // Vérifie si le nombre maximum de coups a été atteint
            if (currentHits >= requiredHits)
            {
                // Si le nombre maximum de coups a été atteint, détruis l'ennemi
                StartCoroutine(DelayedDestroyAndSpawn());
            }
            else
            {
                // Si le nombre maximum de coups n'a pas été atteint, spawn un nouvel objet
                StartCoroutine(DelayedSpawn());
            }
        }
    }

    IEnumerator DelayedSpawn()
    {
        // Attends pendant 2 à 3 secondes
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        Debug.Log("Spawning delayed piece");

        // Fais spawn du nouvel objet
        Instantiate(spawnPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator DelayedDestroyAndSpawn()
    {
        // Attends pendant 2 à 3 secondes
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        // Fais spawn du nombre correct de pièces avant de détruire l'ennemi
        for (int i = 0; i < maxHits; i++)
        {
            Debug.Log("Spawning piece");
            Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        }

        // Détruit l'ennemi
        Destroy(gameObject);
    }
}
