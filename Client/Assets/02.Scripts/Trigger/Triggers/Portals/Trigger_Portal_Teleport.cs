using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Portal_Teleport : Trigger_Portal_Base
{
    [SerializeField] private Transform _teleportTs;
    public override void Trigger()
    {
        _playerController.transform.position = _teleportTs.position;
    }
    public override void OffTrigger() { }

}
