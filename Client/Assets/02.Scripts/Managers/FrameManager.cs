using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager
{
    public static void SetFrame(float frame)
    {
        Application.targetFrameRate = (int)frame;
    }

    // To do : 퀄리티 조정도 넣을 예정
}
