using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

[CreateAssetMenu(fileName ="New StageSO", menuName ="SO/Stage")]
public class StageSO : ScriptableObject
{
    public int _stageIndex;
    public string _stageTitle;
    public Sprite _stageSprite;
    public string _stageProducer;

    public PlayerModeType _stageMode;

    public bool _isMain;
    public bool _isComming;

    public float _processSliderValue;
    public float _processSliderMaxValue;

}
