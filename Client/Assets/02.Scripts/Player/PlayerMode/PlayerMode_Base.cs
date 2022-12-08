using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PlayerMode_Base : MonoBehaviour
{
    protected PlayerController _playerController;
    protected CustomGravity _customGravity = null;
    protected SpeedManager _speedManager = null;
    protected Rigidbody _rigidbody = null;

    protected Transform _playerTs;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpPower;

    protected LayerMask _groundLayerMask;


    private void Start() => Init();

    void Init()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerTs = _playerController.transform;

        _customGravity = _playerController.CustomGravity;
        _speedManager = _playerController.SpeedManager;
        _rigidbody = _playerController.Rigidbody;

        _groundLayerMask = LayerMask.GetMask("Ground");

        UseInit();
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
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            CanJump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || CheckGround());
            yield return new WaitForFixedUpdate();
        }
    }


    // �÷��̾� �ʼ� ���
    // ����, �̵�, 

    public virtual void FixedUpdate() => Move();

    /// <summary>
    /// �׶���� ��Ҵ��� üũ
    /// </summary>
    /// <returns></returns>
    public bool CheckGround()
    {
        Ray ray = new Ray(_playerTs.position, _playerController.Gravity);
        if (Physics.Raycast(ray, 0.6f, _groundLayerMask))
        {
            return true;
        }

        return false;
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
