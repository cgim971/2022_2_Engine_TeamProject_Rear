using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SizeManager : MonoBehaviour
{
    #region Public Property
    public Vector3 Size => _size;
    #endregion

    private Vector3 _initSize = Vector3.one;
    [SerializeField] private Vector3 _size = Vector3.one;

    private void Start()
    {
        SetSize(_size);
    }

    public void SetSize(Vector3 size, float duration = 0.2f)
    {
        _size = size;
        SetSizing(duration);
    }
    public void SetSize(float duration = 0.2f)
    {
        _size = _initSize;
        SetSizing(duration);
    }
    public void SetSizing(float duration) => transform.DOScale(_size, duration);
}
