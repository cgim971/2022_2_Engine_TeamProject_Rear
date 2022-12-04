using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInfo : MonoBehaviour
{
    Button _stageBtn;
    private void Start()
    {
        _stageBtn = GetComponent<Button>();
        _stageBtn.onClick.AddListener(() => GameManager.Instance.sceneManager.LoadingScene("Stage_1"));
    }
}
