using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Spider : PlayerMovement_Base
{
    public override void Move() { }
    public override void Jumping() { }
    public override void Animation() { }


    public override IEnumerator OnClick()
    {
        yield return null;
    }
}
