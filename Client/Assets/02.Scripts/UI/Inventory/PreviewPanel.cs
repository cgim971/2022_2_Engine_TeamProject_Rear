using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreviewPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PreviewModel _previewModel;


    Vector2 _mousePosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _mousePosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 rotate = eventData.position - _mousePosition;
        _previewModel.SetModelRotation(rotate);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        _previewModel.SetClick(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _previewModel.SetClick(false);
    }
}
