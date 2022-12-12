using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class StageManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private StageListSO _stageList;

    private int _stageCount, _targetIndex;
    private float[] _stageOffset;
    private float _distance, _targetPos, _curPos;
    private bool _isDrag;

    [SerializeField] private GameObject _stagePanel;
    [SerializeField] private RectTransform _content;
    private StageInfo _currentStageInfo = null;
    Dictionary<float, StageInfo> _stageInfoDictionary = new Dictionary<float, StageInfo>();
    private ScrollRect _scrollRect;
    [SerializeField] private Scrollbar _horizontalScrollbar;

    private void Start()
    {
        _scrollRect = GetComponent<ScrollRect>();
        _stageList = GameManager.Instance.StageListSO;
        _horizontalScrollbar = _scrollRect.horizontalScrollbar;

        _stageCount = _stageList._stageList.Count;
        _stageOffset = new float[_stageCount];
        _distance = 1f / (_stageCount - 1);
        for (int i = 0; i < _stageCount; i++) _stageOffset[i] = _distance * i;

        CreateStage();

        StartCoroutine(Scroll());
    }

    void CreateStage()
    {
        for (int i = 0; i < _stageCount; i++)
        {
            StageSO stage = _stageList._stageList[i];
            GameObject newStagePanel = Instantiate(_stagePanel, _content);
            StageInfo stageInfo = newStagePanel.GetComponent<StageInfo>();
            stageInfo.Init(stage);

            _stageInfoDictionary.Add(_stageOffset[i], stageInfo);
        }
        _targetIndex = 0;
        _currentStageInfo = _stageInfoDictionary[_stageOffset[_targetIndex]];

        _horizontalScrollbar.value = 0;
    }

    int SetPos()
    {
        for (int i = 0; i < _stageCount; i++)
        {
            if (_horizontalScrollbar.value < _stageOffset[i] + _distance * 0.5f && _horizontalScrollbar.value > _stageOffset[i] - _distance * 0.5f)
            {
                return _targetIndex = i;
            }
        }
        return 0;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _curPos = SetPos();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _isDrag = true;
        if (eventData.delta.x > 30 && _targetIndex != 0)
        {
            _currentStageInfo.OffPanel();
        }
        else if (eventData.delta.x < -30 && _targetIndex != _stageCount)
        {
            _currentStageInfo.OffPanel();
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _isDrag = false;
        _targetPos = SetPos();

        if (_curPos == _targetPos)
        {
            if (eventData.delta.x > 18 && _curPos - _distance >= 0)
            {
                --_targetIndex;
            }
            else if (eventData.delta.x < -18 && _curPos + _distance <= 1.0f)
            {
                ++_targetIndex;
            }
        }
        _currentStageInfo = _stageInfoDictionary[_stageOffset[_targetIndex]];
    }

    IEnumerator Scroll()
    {
        while (true)
        {
            yield return new WaitUntil(() => !_isDrag);
            var tween = DOTween.To(() => _horizontalScrollbar.value, x => _horizontalScrollbar.value = x, _stageOffset[_targetIndex], 0.1f);
            yield return tween.WaitForCompletion();
            _currentStageInfo.OnPanel();
            yield return new WaitUntil(() => _isDrag);
        }
    }
}
