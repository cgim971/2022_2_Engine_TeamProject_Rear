using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New StageList", menuName ="SO/List/StageList")]
public class StageListSO : ScriptableObject
{
    public StageSO _lastStage;
    public List<StageSO> _stageList;
}
