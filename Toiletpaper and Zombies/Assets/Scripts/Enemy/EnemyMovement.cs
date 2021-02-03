using UnityEngine;

public class EnemyMovement : MonoBehaviour, iPooled
{
    public EnemyData Data;

    private Vector2 movement;
    private float m_enemySpeed;
    

    public Sprite enemySprite;
    
    private Rigidbody2D rb;
    private Vector2 targetPos;
    [SerializeField] private GameObject target;
    
    
    public void OnSpawn()
    {
        m_enemySpeed = Data.m_Speed;

    }

    void Start()
    {
        
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

            Vector2 movement = new Vector2(x, y).normalized * m_enemySpeed;

            rb.velocity = movement; 
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
