using Define;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Gravity : Object_Base
{
    [SerializeField] private DirType _gravityType;


    public override void OnEffect(PlayerMovement_Base player)
    {
        StartCoroutine(ObjectCenter(player, () => player.PlayerController.SetGravity(_gravityType)));
        Effect();
    }
    public override void OffEffect(PlayerMovement_Base player) { }
    public override void Effect() { }
}
