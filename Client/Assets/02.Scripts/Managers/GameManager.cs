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

    public StageSO StageSO
    {
        get => _stageSO;
        set
        {
            _stageSO = value;
            TryCount = 1;
        }
    }
    // To do : Ǯ�� �Ŵ����� ���� ����

    [SerializeField] private float _frame = 30f;
    private int _tryCount = 1;
    private StageSO _stageSO;

    private void Awake() => Init();

    private void Init()
    {
        uiManager = this.GetComponent<UIManager>();
        sceneManager = this.GetComponent<SceneManager>();

        FrameManager.SetFrame(_frame);
    }
}
