using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Trigger_Portal_ChangeGravity : Trigger_Portal_Base
{
    [SerializeField] private DirType _gravityType;
    public override void Trigger()
    {
        _playerController.SetGravity(_gravityType);
    }
    public override void OffTrigger() { }

}
