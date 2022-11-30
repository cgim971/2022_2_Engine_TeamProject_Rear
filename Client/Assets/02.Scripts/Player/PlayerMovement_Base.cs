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

    protected Transform _playerTs;
    protected Transform _modelTs;
    protected Transform _colliderTs;

    #region Move Property
    #region Move
    [SerializeField] protected Vector3 _dir;
    protected Vector3 _up;

    [SerializeField] protected float _speed;
    #endregion
    #region Jump
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

    public void Init()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _customGravity = _playerController.CustomGravity;
        _speedManager = _playerController.SpeedManager;
        _rigidbody = _playerController.Rigidbody;

        _playerTs = _playerController.transform;
        _modelTs = transform?.Find("GimbalLockObject")?.Find("Model");
        if(_modelTs == null) transform.Find("Model"); 
        _colliderTs = transform.Find("Collider");

        _up = _customGravity._gravity * (-1);

        // 이거 수정해야함
        UseInit();
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
