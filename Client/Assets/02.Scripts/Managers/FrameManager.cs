using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : MonoBehaviour
{

    public void SetFrame(float frame)
    {
        Application.targetFrameRate = (int)frame;
    }
}
