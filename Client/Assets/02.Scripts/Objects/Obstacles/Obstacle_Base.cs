using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle_Base : Object_Base
{
    public override void OnEffect(PlayerMovement_Base player)
    {
        Debug.Log("Die");
        SceneManager.LoadScene("Stage_1");
    }
    public override void OffEffect(PlayerMovement_Base player) { }
}
