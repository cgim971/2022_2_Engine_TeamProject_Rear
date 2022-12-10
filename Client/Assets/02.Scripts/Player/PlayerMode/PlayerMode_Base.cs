using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define.Math;


public abstract class PlayerMode_Base : MonoBehaviour
{
    protected PlayerController _playerController;
    protected CustomGravity _customGravity = null;
    protected SpeedManager _speedManager = null;
    protected SizeManager _sizeManager = null;
    protected Rigidbody _rigidbody = null;

    protected Transform _playerTs;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpPower;

    protected LayerMask _groundLayerMask;
    protected bool _isExtraJump = false;

    public void Init()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerTs = _playerController.transform;

        _customGravity = _playerController.CustomGravity;
        _speedManager = _playerController.SpeedManager;
        _sizeManager = _playerController.SizeManager;
        _rigidbody = _playerController.Rigidbody;

        _groundLayerMask = LayerMask.GetMask("Ground");
    }

    /// <summary>
    /// ��� �� ������ �ʱ� ����
    /// </summary>
    public virtual void UseInit()
    {
        StartCoroutine(InputTouch());
        _customGravity.SetGravity(true);
    }


    /// <summary>
    /// TouchCheck
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerator InputTouch()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            CanJump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || CheckGround());
            yield return new WaitForFixedUpdate();
        }
    }

    public void SetIsExtraJump(bool isExtraJump) => _isExtraJump = isExtraJump;

    // �÷��̾� �ʼ� ���
    // ����, �̵�, 

    public virtual void FixedUpdate()
    {
        Move();
        CheckObstacle();
    }
    /// <summary>
    /// �׶���� ��Ҵ��� üũ
    /// </summary>
    /// <returns></returns>
    public bool CheckGround()
    {
        float distance = (VectorAbs(_playerController.Gravity) * _sizeManager.Size.x).magnitude / 2 + 0.1f;
        Ray ray = new Ray(_playerTs.position, _playerController.Gravity);
        if (Physics.Raycast(ray, distance, _groundLayerMask))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// �տ� ������Ʈ�� �ִٸ�
    /// </summary>
    public void CheckObstacle()
    {
        float distance = (VectorAbs(_playerController.Dir) * _sizeManager.Size.x).magnitude / 2 + 0.1f;
        Ray ray = new Ray(_playerTs.position, _playerController.Dir);
        if (Physics.Raycast(ray, distance, _groundLayerMask))
        {
            TriggerManager.Instance.OnDeath();
            return;
        }
    }

    public abstract void Move();

    /// <summary>
    /// ���� �Լ� 
    /// </summary>
    public abstract void Jump();
    /// <summary>
    /// ���� �������� üũ �Լ� 
    /// </summary>
    public abstract void CanJump();
    /// <summary>
    /// �ִϸ��̼�
    /// </summary>
    public abstract void Animation();
}
