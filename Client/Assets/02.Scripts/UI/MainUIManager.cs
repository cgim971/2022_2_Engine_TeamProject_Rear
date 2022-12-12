using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{

    private StageListSO _stageList;
    [SerializeField] private GameObject _stagePanel;
    [SerializeField] private RectTransform _content;
    private StageInfo _currentStageInfo = null;
    List<StageInfo> _stageInfoList = new List<StageInfo>();
    [SerializeField] private Scrollbar _horizontalSlider;

    private void Start()
    {
        _stageList = GameManager.Instance.StageListSO;

        CreateStage();
    }

    void CreateStage()
    {
        foreach (StageSO stage in _stageList._stageList)
        {
            GameObject newStagePanel = Instantiate(_stagePanel, _content);
            StageInfo stageInfo = newStagePanel.GetComponent<StageInfo>();
            stageInfo.Init(stage);

            _stageInfoList.Add(stageInfo);
        }

        _currentStageInfo = _stageInfoList[0];
        _currentStageInfo.OnPanel();

        _horizontalSlider.value = 0;
        Debug.Log(_horizontalSlider.value);
    }

    public void OnScroll()
    {
        //_currentStageInfo.OffPanel();
        Debug.Log(_horizontalSlider.value);

    }
}
