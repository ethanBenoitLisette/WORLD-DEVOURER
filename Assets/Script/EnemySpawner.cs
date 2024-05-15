using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRadius = 15;
    public float spawnDelay = 2f;

    private float initialIncreasePerDeath = 30f; 
    private float currentLifeIncrease = 30f;
    private int maxEnemyCount = 5; 

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyPrefab.tag);
        if (enemies.Length >= maxEnemyCount)
        {
            return; 
        }

        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 randomPosition = transform.position + new Vector3(randomDirection.x, randomDirection.y, 0) * spawnRadius;
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        IncreaseEnemyLife(newEnemy);
    }

    private void IncreaseEnemyLife(GameObject enemy)
    {
        eatEnemy enemyScript = enemy.GetComponent<eatEnemy>();
        if (enemyScript != null)
        {
            enemyScript.life += currentLifeIncrease;
            currentLifeIncrease += initialIncreasePerDeath;
        }
    }
}
