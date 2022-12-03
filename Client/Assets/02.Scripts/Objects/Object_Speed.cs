using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Speed : Object_Base
{
    [SerializeField] private float _speed = 1f;

    public override void OffEffect(PlayerMovement_Base player)
    {
        player.SpeedManager.SetSpeed(_speed);
    }

    public override void OnEffect(PlayerMovement_Base player) { }

    public override void Effect() { }
}
