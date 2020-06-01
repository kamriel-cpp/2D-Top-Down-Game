using System;
using UnityEngine;
using Assets.Scripts.Extensions;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private bool _autoTargetPlayer = true;
    [SerializeField] [Range(0.1f, 0.5f)] private float _mouseSensivity = 0.3f;
    [SerializeField] [Range(0.4f, 0.8f)] private float _acceleration = 0.6f;

    private Rigidbody2D _rigidbody;
    private Transform _selfTransform;
    private Transform _targetTransform;
    private Rigidbody2D _targetRigidbody;
    private float _targetSpeed;
    private float _zAxisOffset;

    private void Start()
    {
        if (_autoTargetPlayer)
            FindAndTargetPlayer();

        _rigidbody = GetComponent<Rigidbody2D>();
        _selfTransform = GetComponent<Transform>();
        _zAxisOffset = _selfTransform.position.z;

        if (_target == null || _selfTransform == null)
            return;

       _targetRigidbody = _target.GetComponent<Rigidbody2D>();
        _targetTransform = _target.GetComponent<Transform>();
        _targetSpeed = _target.GetMovementSpeed();

        _selfTransform.position = new Vector3(_targetTransform.position.x, _targetTransform.position.y, _zAxisOffset);
    }

    private void LateUpdate()
    {
        if (_autoTargetPlayer && (_target == null || !_target.gameObject.activeSelf))
            FindAndTargetPlayer();

         FollowTarget(Time.deltaTime);
    }

    private void SetZAxisToDefault()
    {
        _selfTransform.position = new Vector3(_selfTransform.position.x, _selfTransform.position.y, _zAxisOffset);
    }

    private void Move(Vector2 velocity, float deltaTime)
    {
        _selfTransform.position += (Vector3)velocity * _acceleration * deltaTime;
        SetZAxisToDefault();
    }

    private void Move(Vector3 velocity, float deltaTime)
    {
        _selfTransform.position += velocity * _acceleration * deltaTime;
        SetZAxisToDefault();
    }

    private void FollowTarget(float deltaTime)
    {
       if (deltaTime <= 0f || _target == null) return;
        if (_targetTransform.position.Round() == _selfTransform.position.Round()) return;

        Vector3 velocity = Vector3.zero;

        if (_mouseSensivity > 0f)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = (_targetTransform.position + mousePosition * _mouseSensivity) / (1f + _mouseSensivity) - _selfTransform.position;
        }
        else
            velocity = _targetTransform.position - _selfTransform.position;

        _rigidbody.velocity = velocity * _targetSpeed * _acceleration * Time.deltaTime;
    }

    public void FindAndTargetPlayer()
    {
        var targetObj = GameObject.FindGameObjectWithTag("Player");

        if (targetObj)
            SetTarget(targetObj.transform);
    }

    public void SetTarget(Transform newTransform)
    {
        _targetTransform = newTransform;
    }

    public Transform Target
    {
        get { return _targetTransform; }
    }
}
