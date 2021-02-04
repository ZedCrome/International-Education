using UnityEngine;

public class EnemyMovement : MonoBehaviour, iPooled
{
    public EnemyData Data;

    
    private float m_enemySpeed;
    
    private Rigidbody2D rb;
    private Vector2 targetPos;

    public BoxCollider2D Col;

    private Vector2 SpawnLoc;
    
    public void OnSpawn()
    {
        m_enemySpeed = Data.m_Speed;
        SpawnLoc = gameObject.transform.position;
        Col.enabled = true;
    }

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        targetPos = Data.m_Target.transform.position;
    }
    
    
    void FixedUpdate()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        targetPos = SpawnLoc;
        m_enemySpeed += 5;
        Col.enabled = false;
    }

}
