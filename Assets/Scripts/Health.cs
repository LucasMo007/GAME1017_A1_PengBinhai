using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
     void OnTriggerEnter2D(Collider2D other)
    {
        DanmageDealer damageDealer = other.gameObject.GetComponent<DanmageDealer>();
     if(damageDealer != null)
        
        
        { TakeDamage (damageDealer.GetDamage());
            damageDealer.Hit();


        }
    }
    void TakeDamage(int damage )
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
