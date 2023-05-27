using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DamageProjectile : Projectile
{
    private void Start()
    {
        if (tag == "Fireball")
        {
            transform.Rotate(0, 0, -90);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<Player>().DamagePlayer();
            FindObjectOfType<ParticlePlayer>().PlayHit(transform.position);
            Destroy(gameObject);
        }
    }
}
