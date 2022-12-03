using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;
public class Object_Direction : Object_Base
{
    [SerializeField] private DirType _dirType;
    public override void OffEffect(PlayerMovement_Base player)
    {
        player.SetDirection(_dirType);
        Effect();
    }

    public override void OnEffect(PlayerMovement_Base player) { }

    public override void Effect() { }
}
