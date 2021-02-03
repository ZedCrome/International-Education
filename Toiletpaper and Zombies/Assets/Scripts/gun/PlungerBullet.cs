using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerBullet : MonoBehaviour, iPooled
{
    public Rigidbody2D rb;
    [Header("projectile Speed")]
    public float m_force;

    [Header("Explosive radius")]
    public float m_radius;

    [Header("Damage")]
    public int m_damage;


    public void OnSpawn()
    {
        rb.AddForce(transform.right * m_force);
        Invoke("Destroy", 2f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, m_radius);

            foreach (var hitCollider in hitColliders)
            {
               
                var enemy = hitCollider.GetComponent<EnemyHealth>();
                if (enemy)
                {
                    
                    enemy.currentHP(m_damage);
                    Debug.Log(m_damage);
                    
                }

            }
            gameObject.SetActive(false);
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    
}
