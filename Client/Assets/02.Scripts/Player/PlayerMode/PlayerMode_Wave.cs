using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Wave : PlayerMode_Base
{
    private Vector3 _upDir;
    bool _isUp = false;
    [SerializeField] private float _angle = 1f;

    // ground와 닿으면 일직선 코드 필요


    public override void UseInit()
    {
        base.UseInit();

        _customGravity.SetGravity(false);
        Jump();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        SetDir();
    }

    public override void Move() => _rigidbody.MovePosition(_playerTs.position + _upDir * _speed * _speedManager.Speed * Time.deltaTime);

    public override IEnumerator InputTouch()
    {
        while (true)
        {
            yield return new WaitUntil(() => _playerController.Touch == TouchState.DOWN);
            _isUp = true;
            Jump();
            yield return new WaitUntil(() => _playerController.Touch == TouchState.UP);
            _isUp = false;
            Jump();
            yield return new WaitForFixedUpdate();
        }
    }

    public void SetDir()
    {
        float distance = _upDir.magnitude + 0.1f;
        Ray ray = new Ray(_playerTs.position, _upDir);
        if (Physics.Raycast(ray, distance, _groundLayerMask))
        {
            _upDir = _playerController.Dir;
        }
    }

    public override void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _upDir = _isUp ? (_playerController.Dir + _playerController.Gravity * _angle * -1) : (_playerController.Dir + _playerController.Gravity * _angle);
    }

    public override void Animation() { }

    public override bool CanJump() => true;
}
