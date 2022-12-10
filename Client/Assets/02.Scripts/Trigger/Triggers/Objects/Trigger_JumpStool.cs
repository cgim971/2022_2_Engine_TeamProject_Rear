using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_JumpStool : Trigger_Base
{
    // ´êÀ¸¸é Á¡ÇÁ‰Î
    public override void Trigger()
    {
        _playerController.Jump();
    }

    public override void OffTrigger() { }

}
