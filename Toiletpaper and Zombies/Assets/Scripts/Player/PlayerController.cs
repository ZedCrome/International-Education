using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    [SerializeField] private float speed;
    private Vector2 movement;
    private Rigidbody2D rb;
    //camera
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        cam = Camera.main;
    }

    void Update()
    {
        //player movement
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

        //mouse movement
        Vector3 mouse = Input.mousePosition;

        Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenpoint.x, mouse.y - screenpoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }
}
