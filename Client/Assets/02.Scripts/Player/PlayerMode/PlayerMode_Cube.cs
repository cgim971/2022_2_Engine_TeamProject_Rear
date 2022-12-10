using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Cube : PlayerMode_Base
{
    public override void Move() => _rigidbody.MovePosition(_playerTs.position +  _playerController.Dir* _speed * _speedManager.Speed * Time.deltaTime);

    public override void Animation()
    {

    }

    public override void CanJump()
    {
        // 땅과 닿음
        if (CheckGround())
        {
            Jump();
            return;
        }
        // 추가로 점프가 가능한지
        else if (_isExtraJump == true)
        {
            _isExtraJump = false;
            Jump();
            return;
        }
    }

    public override void Jump()
    {
        Animation();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_playerController.Gravity * _jumpPower * -1, ForceMode.VelocityChange);
    }

}
