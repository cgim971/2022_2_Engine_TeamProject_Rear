using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIManager uiManager { get; private set; }
    public SceneManager sceneManager { get; private set; }
    public int TryCount
    {
        get => _tryCount++;
        set => _tryCount = value;
    }

    public StageSO CurrentStageSO
    {
        get => _currentStageSO;
        set
        {
            _currentStageSO._stageIndex = value._stageIndex;
            _currentStageSO._stageName = value._stageName;
            _currentStageSO._stageMode = value._stageMode;

            TryCount = 1;
        }
    }
    public StageListSO StageListSO => _stageList;
    // To do : 풀링 매니저도 넣을 예정

    [SerializeField] private float _frame = 30f;
    private int _tryCount = 1;
    private StageSO _currentStageSO;
    [SerializeField] private StageListSO _stageList;    

    private void Awake() => Init();

    private void Init()
    {
        uiManager = this.GetComponent<UIManager>();
        sceneManager = this.GetComponent<SceneManager>();
        _currentStageSO = _stageList._stageList[0];
        

        FrameManager.SetFrame(_frame);
    }
}
