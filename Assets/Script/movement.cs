using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

            // Vérifiez si la position cible est au-dessus du personnage
            if (target.y > transform.position.y)
            {
                // Si c'est le cas, ajustez la position cible à la même hauteur que le personnage
                target.y = transform.position.y;
            }
            else if (target.y < transform.position.y)
            {
                // Si la position cible est en dessous du personnage, annulez le déplacement vers le bas
                target = transform.position;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}