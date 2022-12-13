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

    public StageListSO StageListSO => _stageList;
    public StageSO CurrentStageSO => _currentStageSO;
    // To do : 풀링 매니저도 넣을 예정

    [SerializeField] private float _frame = 30f;
    private int _tryCount = 1;
    [SerializeField] private StageListSO _stageList;
    [SerializeField] private StageSO _currentStageSO;

    private void Awake() => Init();

    private void Init()
    {
        uiManager = this.GetComponent<UIManager>();
        sceneManager = this.GetComponent<SceneManager>();

        FrameManager.SetFrame(_frame);
    }

    public void Stage(StageSO stageSO) => _currentStageSO = stageSO;
}
