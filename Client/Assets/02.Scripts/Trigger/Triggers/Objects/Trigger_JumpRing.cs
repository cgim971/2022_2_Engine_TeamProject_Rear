using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_JumpRing : Trigger_Base
{
    // �� �� �� ���� �����ϰ� �ڵ带 ���ľ� ��
    public override void Trigger()
    {
        _playerController.ExtraJump();
    }
    public override void OffTrigger()
    {
        _playerController.ExtraJump(false);
    }

}
