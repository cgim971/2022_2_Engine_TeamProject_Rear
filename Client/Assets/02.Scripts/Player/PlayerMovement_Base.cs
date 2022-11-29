using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement_Base : MonoBehaviour
{
    protected PlayerController _playerController;
    protected CustomGravity _customGravity;
    protected SpeedManager _speedManager;
    protected Rigidbody _rigidbody;

    [SerializeField] protected Vector3 _velocity;
    [SerializeField] protected Vector3 _up;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpPower;

    [SerializeField] protected LayerMask _groundLayerMask;

    private void Start() => Init();

    void Init()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _customGravity = _playerController.CustomGravity;
        _speedManager = _playerController.SpeedManager;
        _rigidbody = _playerController.Rigidbody;

        StartCoroutine(OnClick());
    }

    public virtual void FixedUpdate() => Move();

    public abstract void Move();
    public abstract void Jumping();

    public abstract IEnumerator OnClick();
}
