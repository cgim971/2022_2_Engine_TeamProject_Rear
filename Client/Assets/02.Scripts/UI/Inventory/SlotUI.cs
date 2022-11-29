using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Button _btn;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _lockSprite;


    private PreviewModel _previewModel;
    public PreviewModel PreviewModel
    {
        get => _previewModel;
        set => _previewModel = value;
    }

    private SkinType _skinType;
    public SkinType SkinType
    {
        get => _skinType;
        set => _skinType = value;
    }

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

        if (_skin._lock == true)
        {
            _image.sprite = _lockSprite;
        }
        else
        {
            _image.sprite = _skin._sprite;
        }

        _btn.onClick.AddListener(() =>
        {
            if (_skin._lock == true) return;

            InventoryUI.Instance.PreviewModel.SetModel(_skin._model);
            InventoryUI.Instance.SetCurrentSkin(_skinType, _skin);
        });
    }
}
