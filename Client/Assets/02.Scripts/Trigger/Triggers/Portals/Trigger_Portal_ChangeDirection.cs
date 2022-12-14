using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Trigger_Portal_ChangeDirection : Trigger_Portal_Base
{
    [SerializeField] private DirType _dirType;

    public override void Trigger()
    {
        _playerController.transform.position = transform.position;
        _playerController.SetDir(_dirType);
    }
    public override void OffTrigger() { }
}
