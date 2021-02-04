using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBag : MonoBehaviour, iPooled
{
    private float m_randomX;
    private float m_randomY;

    [Header("raycast range")]
    public float m_range;

    public void OnSpawn()
    {
        HitReg();
    }
    
    private void HitReg()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), m_range);
        if(hit.collider.tag != "floor")
        {
            RandomValue();
        }
    }
    private void RandomValue()
    {
        m_randomX = Random.Range(-5f, 5f);
        m_randomY = Random.Range(-2f, 2f);
        Spawning();
    }
    private void Spawning()
    {
        transform.position = new Vector2(m_randomX, m_randomY);
    }
}
