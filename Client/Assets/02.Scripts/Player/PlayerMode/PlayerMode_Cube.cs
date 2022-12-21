using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMode_Cube : PlayerMode_Base
{
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        CheckObstacle();
    }
    int index = 1;
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
