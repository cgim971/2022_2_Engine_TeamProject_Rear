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
    private Vector2 _pos;

    [SerializeField] private GameObject _stagePanel;
    [SerializeField] private RectTransform _content;
    private StageInfo _currentStageInfo = null;
    Dictionary<float, StageInfo> _stageInfoDictionary = new Dictionary<float, StageInfo>();
    private ScrollRect _scrollRect;
    [SerializeField] private Scrollbar _horizontalScrollbar;


    [SerializeField] private GameObject _leftBtn;
    [SerializeField] private GameObject _rightBtn;

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

        CheckButton();
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
        _pos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _isDrag = true;
        if (eventData.delta.x > 3 && _targetIndex > 0)
        {
            _currentStageInfo.OffPanel();
        }
        else if (eventData.delta.x < -3 && _targetIndex < _stageCount - 1)
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
    }

    IEnumerator Scroll()
    {
        while (true)
        {
            yield return new WaitUntil(() => !_isDrag);
            var tween = DOTween.To(() => _horizontalScrollbar.value, x => _horizontalScrollbar.value = x, _stageOffset[_targetIndex], 0.1f);
            _currentStageInfo = _stageInfoDictionary[_stageOffset[_targetIndex]];
            CheckButton();
            yield return tween.WaitForCompletion();
            _currentStageInfo.OnPanel();
            yield return new WaitUntil(() => _isDrag);
        }
    }

    public void LeftBtn()
    {
        if (_targetIndex > 0)
        {
            StartCoroutine(Left());
        }
    }
    IEnumerator Left()
    {
        _currentStageInfo.OffPanel();
        _isDrag = true;
        yield return null;
        _targetIndex -= 1;
        _isDrag = false;
        CheckButton();
    }

    public void RightBtn()
    {
        if (_targetIndex < _stageCount - 1)
        {
            StartCoroutine(Right());
        }
    }
    IEnumerator Right()
    {
        _currentStageInfo.OffPanel();
        _isDrag = true;
        yield return null;
        _targetIndex += 1;
        _isDrag = false;
        CheckButton();
    }

    public void CheckButton()
    {
        _leftBtn.SetActive(_targetIndex == 0 ? false : true);
        _rightBtn.SetActive(_targetIndex == _stageCount - 1 ? false : true);
    }
}
