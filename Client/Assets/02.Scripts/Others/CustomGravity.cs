using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define.Gravity;

public class CustomGravity : MonoBehaviour
{
    #region Property
    public bool IsGravity => _isGravity;
    #endregion


    private Rigidbody _rigidbody;

    [SerializeField] private float _gravityScale = 4.0f;
    private static float _globalGravity = -9.81f;
    private Vector3 _gravityDir;
    private bool _isGravity = false;

    private void Awake() => Init();

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    private void FixedUpdate() => Gravity();

    private void Gravity()
    {
        if (_isGravity == false) return;

        Vector3 gravity = _globalGravity * _gravityScale * _gravityDir * -1;
        _rigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    /// <summary>
    /// Set Gravity DirType
    /// </summary>
    /// <param name="gravityType"></param>
    public Vector3 SetGravity(DirType gravityType)
    {
        _gravityDir = GetGravity(gravityType);
        return _gravityDir;
    }

    public void SetGravity(bool isGravity) => _isGravity = isGravity;
}
