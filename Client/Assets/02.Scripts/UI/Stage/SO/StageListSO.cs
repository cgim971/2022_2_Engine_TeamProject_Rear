using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New StageList", menuName = "SO/List/StageList")]
public class StageListSO : ScriptableObject
{
    public List<StageSO> _stageList;

    public void Init(List<float> stageList)
    {
        int index = 0;
        foreach(StageSO stage in _stageList)
        {
            stage._processSliderValue = stageList[index++];
        }
    }
}
