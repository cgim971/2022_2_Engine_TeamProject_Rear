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
        foreach (StageSO stage in _stageList)
        {
            stage._processSliderValue = stageList[index++];
        }
    }

    public void Save()
    {
        List<float> processValue = new List<float>();
        foreach (StageSO stage in _stageList)
        {
            processValue.Add(stage._processSliderValue);
        }

        GameManager.Instance.saveManager.SetProcessValue(processValue);
    }

}
