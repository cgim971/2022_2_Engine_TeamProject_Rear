using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Define.Direction;

public abstract class PlayerMovement_Base : MonoBehaviour
{
    #region Property
    public PlayerController PlayerController => _playerController;
    public CustomGravity CustomGravity => _customGravity;
    public SpeedManager SpeedManager => _speedManager;
    #endregion


    protected PlayerController _playerController;
    protected CustomGravity _customGravity;
    protected SpeedManager _speedManager;
    protected Rigidbody _rigidbody;


    protected Transform _playerTs;
    protected Transform _modelTs;
    protected Transform _colliderTs;


    #region Move Property
    #region Move
    [Header("World Direction")]
    [SerializeField] private DirType _dirType;
    // ���� ����
    protected Vector3 _dir;
    // �߷� �ݴ� �� - �̰� ���ľ� ��
    // �߷��� �ٲ� �� ���� ��ġ�� �ڵ� ����
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

    /// <summary>
    /// �ʱ� ���� �Լ�
    /// </summary>
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

        _up = _customGravity.GravityDir * (-1);

        _dir = GetDirection(_dirType);
        UseInit();
    }


    /// <summary>
    /// ������ �ٲ�� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="dirType"></param>
    public void SetDirection(DirType dirType = DirType.NONE)
    {
        _dirType = dirType;
        _dir = GetDirection(dirType);
        this?.GetComponent<PlayerMovement_Cube>()?.SetGimbalLockObjectRotation();
    }


    /// <summary>
    /// ��� �� �� �θ��� �Լ�
    /// </summary>
    public abstract void UseInit();

    public virtual void FixedUpdate() => Move();

    /// <summary>
    /// �̵� �Լ�
    /// </summary>
    public abstract void Move();
    /// <summary>
    /// ���� �Լ�
    /// </summary>
    public abstract void Jumping();
    /// <summary>
    /// �ִϸ��̼� �Լ�
    /// </summary>
    public abstract void Animation();

    /// <summary>
    /// Ŭ���� �Ǵ��� üũ�ϴ� �ڷ�ƾ
    /// </summary>
    /// <returns></returns>
    public abstract IEnumerator OnClick();
}
