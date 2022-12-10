using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Ship : PlayerMode_Base
{
    private Vector3 _upDir;
 
    public override void Move() => _rigidbody.MovePosition(_playerTs.position + _upDir * _speed * _speedManager.Speed * Time.deltaTime);

    public override IEnumerator InputTouch()
    {
        _upDir = _playerController.Dir;
        Debug.Log(_upDir);
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Jump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            JumpingEnd();
            yield return new WaitForFixedUpdate();
        }
    }
    public override void Jump()
    {
        _rigidbody.velocity = Vector3.zero;
        _upDir = (_playerController.Dir + _playerController.Gravity * -1);
        _customGravity.SetGravity(false);
    }

    public void JumpingEnd()
    {
        _rigidbody.velocity = Vector3.zero;
        _upDir = _playerController.Dir;
        _customGravity.SetGravity(true);
    }

    public override void Animation() { }

    public override void CanJump() { }



}
