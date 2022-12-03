using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Portal : Object_Base
{
    [SerializeField] private Transform _portalTs;
    public override void OffEffect(PlayerMovement_Base player)
    {
        player.PlayerController.SetPortal(_portalTs);
    }

    public override void OnEffect(PlayerMovement_Base player) { }
    public override void Effect() { }
}
