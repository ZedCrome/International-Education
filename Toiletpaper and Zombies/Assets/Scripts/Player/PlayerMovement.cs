using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;

    private Vector2 movement;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.y != 0)
        {
            movement.x = 0;
        }
        if (movement.x != 0)
        {
            movement.y = 0;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

}
