using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratBullet : MonoBehaviour
{
    public float bulletSpeed = 500;

    public GameObject target;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float x = (target.transform.position.x - transform.position.x);
        float y = (target.transform.position.y - transform.position.y);

        Vector2 direction = new Vector2(x, y).normalized * (bulletSpeed * Time.deltaTime);
        
        transform.Translate(direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject, 0.01f);
    }
}
