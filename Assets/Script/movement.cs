using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;

    [SerializeField] float speed = 3f;

    // Variables pour le d�placement libre
    private Vector3 target;
    private bool isMovingToMouse = false;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // D�placement par les touches fl�ch�es
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }

        movementVector *= speed;

        // D�placement vers la position cliqu�e
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != gameObject)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;

                isMovingToMouse = true;
            }
        }

        // Si le joueur se d�place vers la position cliqu�e, d�sactive le d�placement par les touches fl�ch�es
        if (isMovingToMouse)
        {
            rgbd2d.velocity = (target - transform.position).normalized * speed;

            // V�rifie si le joueur est arriv� � la destination
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                isMovingToMouse = false;
                rgbd2d.velocity = Vector2.zero;
            }
        }
        else
        {
            // Si le joueur n'est pas en d�placement vers la position cliqu�e, utilise le d�placement par les touches fl�ch�es
            rgbd2d.velocity = movementVector;
        }
    }

    // D�sactive la rotation lors des collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rgbd2d.freezeRotation = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rgbd2d.freezeRotation = false;
    }
}