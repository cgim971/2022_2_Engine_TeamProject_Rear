using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Robot : PlayerMode_Base
{
    private bool _isJump = false;
    public override void Move() => _rigidbody.MovePosition(_playerTs.position + (_playerController.Dir + _playerController.Gravity * -1) * _speed * _speedManager.Speed * Time.deltaTime);

    public override IEnumerator InputTouch()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Jump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            JumpingEnd();
            yield return new WaitForFixedUpdate();
        }
    }

    // 점프 조절 가능
    public override void Animation()
    {

    }

    public override void CanJump()
    {
        
    }

    public override void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _customGravity.SetGravity(false);
    }
    public void JumpingEnd()
    {
        _rigidbody.velocity = Vector3.zero;
        _customGravity.SetGravity(true);
    }
}
