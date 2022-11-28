using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Button _btn;

    private SkinSO _skin;
    public SkinSO Skin
    {
        get => _skin;
        set => _skin = value;
    }

    private ScrollRect _horizontalView;
    public ScrollRect HorizontalView
    {
        get => _horizontalView;
        set => _horizontalView = value;
    }

    private ScrollRect _verticalView;
    public ScrollRect VerticalView
    {
        get => _verticalView;
        set => _verticalView = value;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _horizontalView.OnBeginDrag(eventData);
        _verticalView.OnBeginDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        _horizontalView.OnDrag(eventData);
        _verticalView.OnDrag(eventData);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _horizontalView.OnEndDrag(eventData);
        _verticalView.OnEndDrag(eventData);
    }

    public void Init()
    {
        _btn = GetComponent<Button>();

        _btn.onClick.AddListener(() =>
        {
            Debug.Log(_skin._index);
        });
    }
}
