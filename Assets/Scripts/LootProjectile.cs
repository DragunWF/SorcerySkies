using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LootProjectile : Projectile
{
    [SerializeField] int scoreGain;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameState>().IncreaseScore(scoreGain);
            FindObjectOfType<ParticlePlayer>().PlayPickup(transform.position);
            FindObjectOfType<AudioPlayer>().PlayPickup();
            Destroy(gameObject);
        }
    }
}
