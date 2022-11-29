using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIManager uiManager { get; private set; }
    public SceneManager sceneManager { get; private set; }

    [SerializeField] private float _frame = 30f;


    private void Awake() => Init();

    private void Init()
    {
        uiManager = this.GetComponent<UIManager>();
        sceneManager = this.GetComponent<SceneManager>();

        FrameManager.SetFrame(_frame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            sceneManager.LoadingScene("Stage_1");
        }
    }
}
