using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Portal_ChangeSize : Trigger_Portal_Base
{
    [SerializeField] private Vector3 _size = Vector3.one;
    public override void Trigger()
    {
        _playerController.SizeManager.SetSize(_size);
    }
    public override void OffTrigger() { }
}
