using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Obstacle : Trigger_Base
{
    // �浹 �Ǹ� ����
    public override void Trigger()
    {
        TriggerManager.Instance.OnDeath();
    }
    public override void OffTrigger() { }
}
