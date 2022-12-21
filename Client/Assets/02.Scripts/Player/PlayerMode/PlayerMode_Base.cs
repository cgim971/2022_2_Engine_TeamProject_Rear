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
    protected Transform _modelTs;

    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpPower;

    protected LayerMask _groundLayerMask;
    protected bool _isExtraJump = false;
    protected bool _isGravity = false;

    public void Init()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _playerTs = _playerController.transform;
        _modelTs = this.transform.GetChild(0);

        _customGravity = _playerController.CustomGravity;
        _speedManager = _playerController.SpeedManager;
        _sizeManager = _playerController.SizeManager;
        _rigidbody = _playerController.Rigidbody;

        _groundLayerMask = LayerMask.GetMask("Ground");
    }

    /// <summary>
    /// 사용 될 때마다 초기 셋팅
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
            yield return new WaitUntil(() => _playerController.Touch == TouchState.DOWN);
            if (CanJump())
            {
                yield return new WaitUntil(() => _playerController.Touch == TouchState.UP || CheckGround());
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void SetIsExtraJump(bool isExtraJump) => _isExtraJump = isExtraJump;

    // 플레이어 필수 기능
    // 점프, 이동, 

    public virtual void FixedUpdate()
    {
        Move();
        CheckObstacleDir();
    }
    /// <summary>
    /// 그라운드와 닿았는지 체크
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
    /// 앞에 오브젝트가 있다면
    /// </summary>
    public void CheckObstacleDir()
    {
        float distance = (VectorAbs(_playerController.Dir) * _sizeManager.Size.x).magnitude / 2 + 0.1f;
        Ray ray = new Ray(_playerTs.position, _playerController.Dir);
        if (Physics.Raycast(ray, distance, _groundLayerMask))
        {
            TriggerManager.Instance.OnDeath();
            return;
        }
    }

    /// <summary>
    /// 중력의 반대방향과 닿으면
    /// </summary>
    public void CheckObstacle()
    {
        if (_isGravity) return;
        float distance = (VectorAbs(_playerController.Gravity) * _sizeManager.Size.x).magnitude / 2 + 0.1f;
        Ray ray = new Ray(_playerTs.position, _playerController.Gravity * -1);
        if (Physics.Raycast(ray, distance, _groundLayerMask))
        {
            TriggerManager.Instance.OnDeath();
            return;
        }
    }

    public void SetIsGravity(bool isGravity = false)
    {
        _isGravity = isGravity;
    }

    public virtual void Move()
    {
        _rigidbody.MovePosition(_playerTs.position + _playerController.Dir * _speed * _speedManager.Speed * Time.deltaTime);
    }

    /// <summary>
    /// 점프 함수 
    /// </summary>
    public abstract void Jump();
    /// <summary>
    /// 점프 가능한지 체크 함수 
    /// </summary>
    public abstract bool CanJump();
    /// <summary>
    /// 애니메이션
    /// </summary>
    public abstract void Animation();
}
