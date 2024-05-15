using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    public float moveSpeed = 5f; // Vitesse de d�placement vers l'ennemi

    private bool canAttack = true;
    private Vector3 targetPosition; // Position de l'ennemi � attaquer
    private Vector3 initialPosition; // Position initiale du suiveur

    private void Start()
    {
        // Enregistre la position initiale du suiveur
        initialPosition = transform.position;
    }

    void Update()
    {
        if (canAttack)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("EnemyObject"))
                {
                    // Lance l'attaque sur l'ennemi trouv�
                    Attack(collider.gameObject);
                    targetPosition = collider.transform.position; // Stocke la position de l'ennemi
                    break;
                }
            }
        }
        else
        {
            // D�place le personnage vers sa position initiale
            MoveToInitialPosition();
        }
    }

    void Attack(GameObject enemyObject)
    {
        eatEnemy enemy = enemyObject.GetComponent<eatEnemy>();
        if (enemy != null)
        {
            // Animation d'attaque ici
            StartCoroutine(AttackCooldown());
            Debug.Log(attackDamage); 
            enemy.TakeDamage(attackDamage);
            
        }

        Follower newFollow = enemyObject.GetComponent<Follower>();
        if (newFollow != null)
        {
            // R�initialise la position cible lorsque l'alli� a attaqu�
            targetPosition = Vector3.zero;
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void MoveToInitialPosition()
    {
        if (initialPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);

            if (transform.position == initialPosition)
            {
                initialPosition = Vector3.zero;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Affiche la port�e d'attaque dans l'�diteur Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
