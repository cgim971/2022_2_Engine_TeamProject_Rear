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
    // To do : 풀링 매니저도 넣을 예정

    [SerializeField] private float _frame = 30f;
    private int _tryCount = 1;
    [SerializeField] private StageListSO _stageList;

    private void Awake() => Init();

    private void Init()
    {
        uiManager = this.GetComponent<UIManager>();
        sceneManager = this.GetComponent<SceneManager>();

        FrameManager.SetFrame(_frame);
    }


    //Test code
    private void Update()
    {
        // if (Input.GetMouseButtonDown(0)) SoundManager.PlayOnShot(Define.SoundType.EFFECT, "Click");
    }
}
