using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerMovement_Base : MonoBehaviour
{
    protected PlayerController _playerController;
    protected CustomGravity _customGravity;
    protected SpeedManager _speedManager;
    protected Rigidbody _rigidbody;

    #region Move Property
    #region Move
    [SerializeField] protected Vector3 _velocity;
    [SerializeField] protected Vector3 _up;

    [SerializeField] protected float _speed;
    #endregion
    #region Jump
    public UnityEvent Event_Jump;
    [SerializeField] protected float _jumpPower;

    [SerializeField] protected LayerMask _groundLayerMask;

    [SerializeField] protected int _extraJump = 0;
    public int ExtraJump
    {
        get => _extraJump;
        set => _extraJump = value;
    }
    #endregion
    #endregion

    private void Start() => Init();

    void Init()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _customGravity = _playerController.CustomGravity;
        _speedManager = _playerController.SpeedManager;
        _rigidbody = _playerController.Rigidbody;

        StartCoroutine(OnClick());
    }

    /// <summary>
    /// 사용 될 때 부르는 함수
    /// </summary>
    public abstract void UseInit();

    public virtual void FixedUpdate() => Move();

    public abstract void Move();
    public abstract void Jumping();
    public abstract void Animation();

    public abstract IEnumerator OnClick();
}
