using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Wave : PlayerMode_Base
{
    private Vector3 _upDir;
    bool _isUp = false;
    [SerializeField] private float _angle = 1f;

    // ground�� ������ ������ �ڵ� �ʿ�


    public override void UseInit()
    {
        base.UseInit();

        _customGravity.SetGravity(false);
        Jump();
    }

    public override void Move()
    {
        _rigidbody.MovePosition(_playerTs.position + _upDir * _speed * _speedManager.Speed * Time.deltaTime);
    }
    public override IEnumerator InputTouch()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Jump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            yield return new WaitForFixedUpdate();
        }
    }
    public override void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _isUp = !_isUp;
        _upDir = _isUp ? (_playerController.Dir + _playerController.Gravity * _angle * -1) : (_playerController.Dir + _playerController.Gravity * _angle);
    }

    public override void Animation() { }

    public override void CanJump() { }
}
