using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CameraObj : Trigger_Base
{
    [SerializeField] private Vector3 _pos;
    [SerializeField] private Quaternion _rot;

    public override void Trigger()
    {
        _playerController.SetCameraPos(_pos);
        _playerController.SetCameraRot(_rot);
    }
    public override void OffTrigger() { }
}
