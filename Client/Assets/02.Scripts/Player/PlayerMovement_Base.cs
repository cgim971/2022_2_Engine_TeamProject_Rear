using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Base : MonoBehaviour
{

    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected float _speed;
    [SerializeField] protected Vector3 _velocity;
    [SerializeField] protected bool _isClick = false;

    public void OnClick()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        if (_isClick)
        {
            _rigidbody.velocity = _velocity;
        }
    }
}
