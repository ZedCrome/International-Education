using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement")]
    [SerializeField] private float speed;
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + (horizontal * speed), transform.position.y + (vertical * speed));
    }
}
