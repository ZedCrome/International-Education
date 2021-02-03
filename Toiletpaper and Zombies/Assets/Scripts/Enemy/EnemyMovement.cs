using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 movement;
    private float speed;
    public float maxSpeed = 2f;
    public float minSpeed = 3f;

    public Sprite enemySprite;
    
    private Rigidbody2D rb;
    private Vector2 targetPos;
    [SerializeField] private GameObject target;
    
    
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        targetPos = target.transform.position;
    }
    
    
    void FixedUpdate()
    {
        targetPos = target.transform.position;
        MoveEnemy();
    }


    public void MoveEnemy()
    {
        if (Vector2.Distance(transform.position, targetPos) > 0.1)
        {
            float x = (targetPos.x - transform.position.x);
            float y = (targetPos.y - transform.position.y);

            Vector2 movement = new Vector2(x, y).normalized * speed;

            rb.velocity = movement; 
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
