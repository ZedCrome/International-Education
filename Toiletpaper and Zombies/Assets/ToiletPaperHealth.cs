using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPaperHealth : Health
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Enemy collided with Player");
            ChangeHealth(-maxHealth);
        }

        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
