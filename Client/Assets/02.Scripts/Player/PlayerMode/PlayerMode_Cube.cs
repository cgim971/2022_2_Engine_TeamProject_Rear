using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Cube : PlayerMode_Base
{
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        CheckObstacle();
    }

    public override void Animation()
    {

    }

    public override bool CanJump()
    {
        // ���� ����
        if (CheckGround())
        {
            Jump();
            return true;
        }
        // �߰��� ������ ��������
        else if (_isExtraJump == true)
        {
            _isExtraJump = false;
            Jump();
            return true;
        }

        return false;
    }

    public override void Jump()
    {
        Animation();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_playerController.Gravity * _jumpPower * -1, ForceMode.VelocityChange);
    }

}
