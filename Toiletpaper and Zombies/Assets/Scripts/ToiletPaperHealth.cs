using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaperHealth : Health
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Object Destroyed");
            ChangeHealth(-1);
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
