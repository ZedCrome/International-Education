using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerBullet : MonoBehaviour, iPooled
{
    public Rigidbody2D rb;
    public float Force;

    public void OnSpawn()
    {
        rb.AddForce(transform.right * Force);
        Invoke("Destroy", 2f);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    
}
