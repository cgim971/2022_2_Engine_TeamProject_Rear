using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

[CreateAssetMenu(fileName ="New StageSO", menuName ="SO/Stage")]
public class StageSO : ScriptableObject
{
    public int _stageIndex;
    public string _stageName;
    public PlayerModeType _stageMode;

    public bool _isMain;
    public bool _isComming;
}
