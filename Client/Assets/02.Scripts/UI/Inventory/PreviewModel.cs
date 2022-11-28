using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PreviewModel : MonoBehaviour
{
    Sequence _rotationSequence;

    private void Awake()
    {
        _rotationSequence = DOTween.Sequence();
        _rotationSequence.Append(transform.DORotate(new Vector3(360f, 360f, 360f), 4.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1));
        _rotationSequence.Pause();
    }
    private void Start()
    {
        _rotationSequence.Restart();
    }

}
