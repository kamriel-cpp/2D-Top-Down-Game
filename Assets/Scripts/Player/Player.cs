using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private MovementComponent _movementComponent;
    [SerializeField] [Range(100, 1000)] private float _movementSpeed = 500f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementComponent = new MovementComponent(_rigidbody, _movementSpeed);
    }

    private Vector2 GetKeyboardMovementInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Move(Vector2 direction)
    {
        _movementComponent.Move(direction);
    }

    private void Aim(Vector2 target)
    {
        Vector2 direction = (Vector2)_transform.position - target;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Aim(mousePosition);

        Move(GetKeyboardMovementInput());
    }

    public float GetMovementSpeed()
    {
        return _movementSpeed;
    }
}
