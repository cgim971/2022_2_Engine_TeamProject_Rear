using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIManager uiManager { get; private set; }
    public SceneManager sceneManager { get; private set; }
    public SaveManager saveManager { get; private set; }
    public int TryCount
    {
        get => _tryCount++;
        set => _tryCount = value;
    }

    public StageListSO StageListSO => _stageList;
    public StageSO CurrentStageSO => _currentStageSO;
    public float Timer => _timer;


    [SerializeField] private float _frame = 30f;
    private int _tryCount = 1;
    [SerializeField] private StageListSO _stageList;
    [SerializeField] private StageSO _currentStageSO;

    [SerializeField] private float _timer = 0;
    [SerializeField] private int _isTimer = 3;

    private void Awake() => Init();

    private void Init()
    {
        uiManager = this.GetComponent<UIManager>();
        sceneManager = this.GetComponent<SceneManager>();
        saveManager = this.GetComponent<SaveManager>();

        FrameManager.SetFrame(_frame);
    }

    private void Start() => SoundManager.PlayBGM("Wanna");

    public void Stage(StageSO stageSO)
    {
        _currentStageSO = stageSO;
        TimerStart();
    }

    Coroutine _timerCoroutine;
    public void TimerStart()
    {
        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);

        _timerCoroutine = StartCoroutine(Timers());
    }
    public void TimerStop()
    {
        if (_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);
    }

    public IEnumerator Timers()
    {
        _timer = 0f;
        yield return null;

        while (true)
        {
            _timer += Time.deltaTime;
            yield return null;
        }
    }
}
