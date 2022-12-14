using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Robot : PlayerMode_Base
{
    private bool _isJump = false;

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        CheckObstacle();
    }
    public override void Move() => _rigidbody.MovePosition(_playerTs.position + _playerController.Dir * _speed * _speedManager.Speed * Time.deltaTime);


    public override IEnumerator InputTouch()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            CanJump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || _isJump == true);
            yield return new WaitForFixedUpdate();
        }
    }

    // 점프 조절 가능
    public override void Animation()
    {

    }

    public override void CanJump()
    {
        _isJump = false;
        if (CheckGround())
        {
            StartCoroutine(Jumping());
        }
    }

    IEnumerator Jumping()
    {
        yield return null;
    }

    public override void Jump()
    {

    }
}
