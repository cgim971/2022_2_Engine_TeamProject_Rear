using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class StageInfo : MonoBehaviour
{
    private StageSO _stageSO;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Button _stageBtn;


    public void Init(StageSO stageSO)
    {
        _stageSO = stageSO;
        _nameText.text = stageSO._stageName;

        if (stageSO._isComming == false)
            _stageBtn.onClick.AddListener(() => GameManager.Instance.sceneManager.StageScene(_stageSO));
    }

}
