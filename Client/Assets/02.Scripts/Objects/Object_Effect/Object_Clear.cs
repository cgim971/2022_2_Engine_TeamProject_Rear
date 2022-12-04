using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Clear : Object_Base
{
    public override void OnEffect(PlayerMovement_Base player)
    {
        GameManager.Instance.sceneManager.LoadingScene("Stage_1");
    }
    public override void OffEffect(PlayerMovement_Base player) { }
    public override void Effect() { }
}
