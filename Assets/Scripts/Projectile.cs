using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float[] _initialSpeedValues = { 3f, 3.5f, 3.75f, 4f, 4.25f, 4.5f, 5f };
    protected float speed;
    private Rigidbody2D _rigidbody;
    private const float DESPAWN_POINT = -10; // For the y axis

    private void Awake()
    {
        speed = _initialSpeedValues[Random.Range(0, _initialSpeedValues.Length)];
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -speed);
        if (transform.position.y <= DESPAWN_POINT)
        {
            Destroy(gameObject);
        }
    }

}
