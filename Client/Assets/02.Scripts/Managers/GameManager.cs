using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public UIManager uiManager { get; private set; }

    private void Awake() => Init();

    private void Init()
    {
        uiManager = this.GetComponent<UIManager>();
    }
}
