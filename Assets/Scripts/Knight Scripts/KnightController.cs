
using System;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlayerChar
{
    [SerializeField] private Animator animator;
    [SerializeField] private float _speed = 1;

    private SpriteRenderer _spriteRenderer;
    private float _direction;
    private Vector3 _currentTargetCord;
    private Vector3 _moveDirection;

    private void Start()
    {
        _currentTargetCord = transform.position;
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void Move(Vector3 coordinatesToMove)
    {
        _currentTargetCord = coordinatesToMove;
        SetDirectionOfMoving();
        if (_direction < 0) _spriteRenderer.flipX = true;
        else _spriteRenderer.flipX = false;
    }

    private void SetDirectionOfMoving()
    {
        _moveDirection = _currentTargetCord - transform.position;
        _moveDirection.Normalize();
        _direction = _moveDirection.x;
        _moveDirection.x = Math.Abs(_moveDirection.x);
        animator.SetFloat("VectorX", _moveDirection.x);
        animator.SetFloat("VectorY", _moveDirection.y);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTargetCord, Time.deltaTime * _speed);
        if (transform.position == _currentTargetCord) animator.SetBool("IsStaying", true);
        else animator.SetBool("IsStaying", false);
    }
}
