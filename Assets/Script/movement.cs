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
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out hit) || hit.collider.gameObject != gameObject)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;

                if (target.y > transform.position.y)
                {
                    target.y = transform.position.y;
                }
                else if (target.y < transform.position.y)
                {
                    target = transform.position;
                }
               
                
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}