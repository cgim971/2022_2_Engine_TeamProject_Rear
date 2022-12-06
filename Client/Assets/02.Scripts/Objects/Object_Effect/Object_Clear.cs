using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Clear : Object_Base
{
    public override void OnEffect(PlayerMovement_Base player)
    {
        // GameManager.Instance.sceneManager.StageScene("Stage_1");
        // 수정 필요 멈추고 창이 뜨게 할 예정
        SceneManager.LoadScene("StartUI");
    }
    public override void OffEffect(PlayerMovement_Base player) { }
    public override void Effect() { }
}
