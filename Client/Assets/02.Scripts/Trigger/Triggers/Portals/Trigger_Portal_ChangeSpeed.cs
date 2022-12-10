using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Portal_ChangeSpeed : Trigger_Portal_Base
{
    [SerializeField] private float _speed = 1f;
    public override void Trigger()
    {
        _playerController.SpeedManager.SetSpeed(_speed);
    }
    public override void OffTrigger() { }
}
