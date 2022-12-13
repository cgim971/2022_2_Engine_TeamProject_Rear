using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Ball : PlayerMode_Base
{
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
