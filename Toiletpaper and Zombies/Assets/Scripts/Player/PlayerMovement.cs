using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("Movement Restriction")]
    public float m_xValue;
    public float m_yValue;
    
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime;
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x + (horizontal * speed),-m_xValue, m_xValue), 
            Mathf.Clamp(transform.position.y + (vertical * speed), -m_yValue, m_yValue));
    }
}
