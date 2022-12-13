using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PrevPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PrevModel _prevModel;

    Vector2 _mousePosition;
    public void OnBeginDrag(PointerEventData eventData) => _mousePosition = eventData.position;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 rotate = eventData.position - _mousePosition;
        _prevModel.SetModelRotation(rotate);
    }

    public void OnPointerDown(PointerEventData eventData) => _prevModel.SetClick(true);

    public void OnPointerUp(PointerEventData eventData) => _prevModel.SetClick(false);
}
