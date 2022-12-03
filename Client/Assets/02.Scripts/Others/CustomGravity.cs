using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define.Gravity;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _gravityScale = 4.0f;
    private static float _globalGravity = -9.81f;

    [SerializeField] private DirType _gravityType;

    private Vector3 _gravityDir;
    public Vector3 GravityDir => _gravityDir;

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

        _gravityDir = GetGravity(_gravityType);
    }

    private void FixedUpdate() => Gravity();

    private void Gravity()
    {
        if (!_isGravity) return;
        Vector3 gravity = (_globalGravity * -1) * _gravityScale * _gravityDir;
        _gravityValue = gravity;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void SetGravity(DirType gravityType)
    {
        _gravityType = gravityType;
        _gravityDir = GetGravity(_gravityType);
    }
}
