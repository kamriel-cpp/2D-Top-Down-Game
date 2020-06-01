using System;
using UnityEngine;

public class MovementComponent
{
    private Rigidbody2D _rigidbody;
    private float _speed;

    public MovementComponent(Rigidbody2D rigidbody, float speed) 
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }

    public void Move(Vector2 direction)
    {
        _rigidbody.velocity = direction.normalized * _speed * Time.deltaTime;
    }
}
