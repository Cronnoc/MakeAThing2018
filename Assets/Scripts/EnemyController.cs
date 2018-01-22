using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject waypoint1, waypoint2;
    int currentWaypoint;

    public float movementSpeed;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentWaypoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (currentWaypoint == 1)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.position - waypoint2.transform.position);
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            if (transform.rotation.y >= targetRotation.y + 0.1f || transform.rotation.y <= targetRotation.y - 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint1.transform.position, movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.position - waypoint1.transform.position);
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            if (transform.rotation.y >= targetRotation.y + 0.1f || transform.rotation.y <= targetRotation.y - 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 180 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint2.transform.position, movementSpeed * Time.deltaTime);
            }
        }

        if (transform.position.x <= waypoint1.transform.position.x)
        {
            currentWaypoint = 2;
        }
        else if (transform.position.x >= waypoint2.transform.position.x)
        {
            currentWaypoint = 1;
        }
    }
}
