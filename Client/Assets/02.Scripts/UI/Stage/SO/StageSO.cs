using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

[CreateAssetMenu(fileName = "New StageSO", menuName = "SO/Stage")]
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

    public bool _isClear;

    /// <summary>
    /// value가 같거나 크면 클리어
    /// </summary>
    /// <returns></returns>
    public bool IsClear()
    {
        if (!_isClear)
        {
            if (_processSliderValue >= _processSliderMaxValue)
            {
                _isClear = true;
            }
        }

        return _isClear;
    }
}
