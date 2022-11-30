using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Jump : Object_Base
{
    public override void OffEffect(PlayerMovement_Base player)
    {
        player.Jumping();
    }

    public override void OnEffect(PlayerMovement_Base player) { }
}
