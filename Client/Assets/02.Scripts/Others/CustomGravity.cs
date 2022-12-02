using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _gravityScale = 4.0f;
    private static float _globalGravity = -9.81f;

    public Vector3 _gravity;

    private Vector3 _gravityValue = Vector3.zero;
    public Vector3 GravityValue => _gravityValue;

    private bool _isGravity = true;
    public bool IsGravity
    {
        get => _isGravity;
        set => _isGravity = value;
    }

    private void Awake() => Init();

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void FixedUpdate() => Gravity();

    private void Gravity()
    {
        if (!_isGravity) return;
        Vector3 gravity = (_globalGravity * -1) * _gravityScale * _gravity;
        _gravityValue = gravity;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }
}
