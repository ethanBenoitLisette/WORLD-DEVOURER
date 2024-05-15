using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour
{
    public float minSpeed = 3f;
    public float maxSpeed = 7f;
    public float maxDeviationAngle = 65f; // Angle de déviation maximal
    public float minRandomMoveInterval = 1f;
    public float maxRandomMoveInterval = 5f;
    public float randomMoveDuration = 0.5f;
    private bool isRandomMoving = false;
    public Transform player;


    private float currentSpeed;

    private void Start()
    {
        // Trouver automatiquement le joueur et l'assigner à la variable player
        player = GameObject.FindGameObjectWithTag("PlayerObject").transform;

        StartCoroutine(RandomMoveCoroutine());
    }

    private void Update()
    {
        if (player != null && !isRandomMoving)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

            // Oriente le suiveur vers le joueur avec une déviation maximale
            Vector2 directionToPlayer = player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            float clampedAngle = Mathf.Clamp(angle, -maxDeviationAngle, maxDeviationAngle);

            transform.rotation = Quaternion.Euler(0f, 0f, clampedAngle);
        }
    }

    IEnumerator RandomMoveCoroutine()
    {
        while (true)
        {
            float randomInterval = Random.Range(minRandomMoveInterval, maxRandomMoveInterval);
            currentSpeed = Random.Range(minSpeed, maxSpeed);
            yield return new WaitForSeconds(randomInterval);

            // Active le mouvement aléatoire
            isRandomMoving = true;

            // Génère une direction aléatoire dans un angle de 65 degrés par rapport au joueur
            Vector2 directionToPlayer = player.position - transform.position;
            Vector2 randomDirection = Quaternion.Euler(0f, 0f, Random.Range(-maxDeviationAngle, maxDeviationAngle)) * directionToPlayer.normalized;

            // Stocke le temps actuel
            float startTime = Time.time;

            while (Time.time - startTime < randomMoveDuration)
            {
                // Déplace le suiveur dans la direction aléatoire
                transform.Translate(randomDirection * currentSpeed * Time.deltaTime);
                yield return null;
            }

            // Désactive le mouvement aléatoire
            isRandomMoving = false;
        }
    }
}
