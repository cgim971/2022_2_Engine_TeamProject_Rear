using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Trigger_Portal_ChangeMode : Trigger_Portal_Base
{
    [SerializeField] private PlayerModeType _playerMode;
    public override void Trigger()
    {
        _playerController.SetPlayerMode(_playerMode);
    }
    public override void OffTrigger() { }

}
