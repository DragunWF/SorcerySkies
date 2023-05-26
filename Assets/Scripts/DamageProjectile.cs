using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProjectile : Projectile
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Player>().DamagePlayer();
            Destroy(gameObject);
        }
    }
}
