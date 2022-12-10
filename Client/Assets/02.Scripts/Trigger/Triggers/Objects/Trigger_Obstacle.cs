using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Obstacle : Trigger_Base
{
    // 충돌 되면 죽음
    public override void Trigger()
    {
        TriggerManager.Instance.OnDeath();
    }
    public override void OffTrigger() { }
}
