using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Camera : Object_Base
{
    [SerializeField] private Vector3 _newPos;
    [SerializeField] private Vector3 _newRot;

    public override void OffEffect(PlayerMovement_Base player)
    {
        player.PlayerController.SetFollowObj(_newPos, _newRot);
    }

    public override void OnEffect(PlayerMovement_Base player) { }

    public override void Effect() { }
}
