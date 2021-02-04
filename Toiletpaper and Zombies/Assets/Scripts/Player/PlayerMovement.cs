using UnityEngine;

public enum PlayerState
{
    Idle = 0,
    Walking = 1
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private Animator anim;
    PlayerState playerState;

    private SpriteRenderer playerSprite;

    [Header("Movement")]
    [SerializeField] private float speed;

    [Header("Movement Restriction")]
    public float m_xValue;
    public float m_yValue;


    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        Flip();

        float horizontal = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
        float vertical = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime;
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x + (horizontal * speed),-m_xValue, m_xValue), 
            Mathf.Clamp(transform.position.y + (vertical * speed), -m_yValue, m_yValue));

        if (horizontal == 0 && vertical == 0)
        {
            playerState = PlayerState.Idle;
        }
        else
        {
            playerState = PlayerState.Walking;
        }

        anim.SetInteger("PlayerState", (int)playerState);
    }


    private void Flip()
    {
        playerSprite.flipX = transform.position.x < 0;
    }

}
