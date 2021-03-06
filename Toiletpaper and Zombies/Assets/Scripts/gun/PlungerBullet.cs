using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerBullet : MonoBehaviour, iPooled
{
    public Rigidbody2D rb;
    public BoxCollider2D col;
    private Vector2 abc;
    [Header("projectile Speed")]
    public float m_force;

    [Header("Explosive radius")]
    public float m_radius;

    [Header("Damage")]
    public int m_damage;

    public ParticleSystem Explosion;

    public void OnSpawn()
    {
        rb.isKinematic = false;
        col.enabled = true;
        rb.AddForce(transform.right * m_force);
        Invoke("Destroy", 2f);
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector3.zero;
        col.enabled = false;
        Explosion.GetComponent<ParticleSystem>();
        Explosion.Play();
        Vector2 m_boom = transform.position;
        if(collision.gameObject.tag == "Enemy")
        {
            var hitColliders = Physics2D.OverlapCircleAll(m_boom, m_radius);
            abc = m_boom;
            foreach (var hitCollider in hitColliders)
            {
               
                var enemy = hitCollider.GetComponent<EnemyHealth>();
                if (enemy)
                {
                    
                    enemy.currentHP(m_damage);

                    
                }

            }
            
        }

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        Invoke("Destroy", 0.4f);
        
    }
   

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }

}
