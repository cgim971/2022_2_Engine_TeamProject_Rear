using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _gravityScale = 4.0f;
    private static float _globalGravity = -9.81f;

    private Vector3 _gravityValue = Vector3.zero;
    public Vector3 GravityValue => _gravityValue;

    private void Awake() => Init();

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void FixedUpdate() => Gravity();

    private void Gravity()
    {
        Vector3 gravity = _globalGravity * _gravityScale * Vector3.up;
        _gravityValue = gravity;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }
}
