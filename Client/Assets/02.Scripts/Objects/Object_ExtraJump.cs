using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_ExtraJump : Object_Base
{
    public override void OnEffect(PlayerMovement_Base player)
    {
        player.ExtraJump++;
    }
    public override void OffEffect(PlayerMovement_Base player)
    {
        player.ExtraJump = 0;
    }
}
