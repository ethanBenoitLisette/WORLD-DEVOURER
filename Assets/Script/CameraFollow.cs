using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Assure-toi d'attacher le joueur dans l'inspecteur

    void Update()
    {
        if (player != null)
        {
            Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}
