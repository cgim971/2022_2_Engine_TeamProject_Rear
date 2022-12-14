using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Ball : PlayerMode_Base
{
    public override void Animation()
    {
    }

    public override bool CanJump()
    {
        if (CheckGround())
        {
            Jump();
            return true;
        }
        return false;
    }

    public override void Jump()
    {
        Animation();
        _playerController.ReverseGravity();
    }

}
