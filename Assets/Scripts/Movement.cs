using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed;
    public float swipeDeltaForJump;
    public float jumpSpeed;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                rb.AddForce(Vector3.right * movementSpeed * Time.deltaTime);
            }
            else if (Input.GetTouch(0).position.x < Screen.width / 2)
            {
                rb.AddForce(Vector3.left * movementSpeed * Time.deltaTime);
            }

            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).deltaPosition.y > swipeDeltaForJump && IsGrounded())
                {
                    float additionalMovement = Input.GetTouch(i).deltaPosition.y - swipeDeltaForJump;
                    float multiplier = 1.0f + (0.025f * additionalMovement);
                    if (multiplier > 1.5f)
                    {
                        multiplier = 1.5f;
                    }
                    rb.AddExplosionForce(jumpSpeed * multiplier, transform.position, 100);
                    break;
                }
            }
        }


        // Computer Testing code
        if (Input.mousePosition.x > Screen.width / 2 && Input.GetMouseButton(0))
        {
            rb.AddForce(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if (Input.mousePosition.x < Screen.width / 2 && Input.GetMouseButton(0))
        {
            rb.AddForce(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddExplosionForce(jumpSpeed, transform.position, 100);
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.55f))
        {
            return true;
        }
        return false;
    }
}
