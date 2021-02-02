using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 movement;
    private float speed;
    public float maxSpeed = 2f;
    public float minSpeed = 3f;

    private Rigidbody2D rb;
    private Vector2 targetPos;
    public GameObject target;
    
    
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("EnemyTargetPoint");
        targetPos = target.transform.position;
    }
    
    
    void FixedUpdate()
    {
        targetPos = target.transform.position;
        GetTarget();
    }


    public void GetTarget()
    {
        float x = (targetPos.x - transform.position.x);
        float y = (targetPos.y - transform.position.y);

        Vector2 movement = new Vector2(x, y).normalized * speed;

        rb.velocity = movement;
    }
}
