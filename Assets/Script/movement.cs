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
        rgbd2d.constraints = RigidbodyConstraints2D.FreezeRotation; // Ajoutez cette ligne pour verrouiller la rotation de l'axe Z
        movementVector = new Vector3();
        target = transform.position;
    }
    void Update()
    {
        // V�rifie si le clic gauche est appuy�
        if (Input.GetMouseButtonDown(0))
        {
            // Lance un Raycast � partir du point de clic
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Si le Raycast touche un objet
            if (Physics.Raycast(ray, out hit))
            {
                // V�rifie si l'objet touch� est un bouton
                if (hit.collider.CompareTag("Button"))
                {
                    // Si c'est un bouton, ne d�placez pas le personnage
                    Debug.Log("Clic sur le bouton !");
                    return;
                }
                else
                {
                    // Si ce n'est pas un bouton, continuez avec le d�placement normal
                    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    target.z = transform.position.z;
                    isMovingToMouse = true;
                }
            }
        }

        // Si le joueur ne clique pas sur un bouton, le mouvement du personnage est autoris�
        if (!isMovingToMouse)
        {
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
            rgbd2d.velocity = movementVector;
        }
        else
        {
            // D�placer le personnage vers la position du clic de la souris
            rgbd2d.velocity = (target - transform.position).normalized * speed;

            // Si le personnage est suffisamment proche de la position du clic, arr�tez le d�placement
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                isMovingToMouse = false;
                rgbd2d.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rgbd2d.freezeRotation = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        rgbd2d.freezeRotation = false;
    }
}
