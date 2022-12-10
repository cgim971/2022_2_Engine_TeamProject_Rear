using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Ball : PlayerMode_Base
{
    public override void Move() => _rigidbody.MovePosition(_playerTs.position + _playerController.Dir * _speed * _speedManager.Speed * Time.deltaTime);
    public override void Animation()
    {
    }

    public override void CanJump()
    {
        if (CheckGround())
        {
            Jump();
        }
    }

    public override void Jump()
    {
        Animation();
        _playerController.ReverseGravity();
    }

}
