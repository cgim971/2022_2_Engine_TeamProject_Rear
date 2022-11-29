using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class BackPanel : MonoBehaviour, IPointerUpHandler,IPointerDownHandler
{
    public UnityEvent _eventData;

    Vector2 _mousePos = Vector2.down;

    public void OnPointerDown(PointerEventData eventData)
    {
        _mousePos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.position.y - _mousePos.y > 100)
        {
            _eventData?.Invoke();
        }
    }
}
