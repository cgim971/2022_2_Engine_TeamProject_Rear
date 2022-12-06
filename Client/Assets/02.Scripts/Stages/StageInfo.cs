using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInfo : MonoBehaviour
{
    [SerializeField] private StageSO _stageSO;

    Button _stageBtn;
    private void Start()
    {
        _stageBtn = GetComponent<Button>();
        _stageBtn.onClick.AddListener(() => GameManager.Instance.sceneManager.StageScene(_stageSO));
    }
}
