using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_JumpRing : Trigger_Base
{
    // 한 번 더 점프 가능하게 코드를 고쳐야 함
    public override void Trigger()
    {
        _playerController.ExtraJump();
    }
    public override void OffTrigger()
    {
        _playerController.ExtraJump(false);
    }

}
