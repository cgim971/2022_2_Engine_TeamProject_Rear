using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PrevModel : MonoBehaviour
{
    Sequence _rotationSequence;
    bool _isClick = false;

    private void Awake()
    {
        _rotationSequence = DOTween.Sequence().SetAutoKill(false);
        _rotationSequence.AppendInterval(0.1f);
        _rotationSequence.Append(transform.DORotate(new Vector3(360f, 360f, 0f), 7.5f, RotateMode.FastBeyond360).SetEase(Ease.InOutCubic)).SetLoops(-1, LoopType.Yoyo);
        _rotationSequence.Pause();
    }

    private void Start()
    {
        _rotationSequence.Restart();
    }

    public void SetClick(bool isClick)
    {
        _isClick = isClick;

        if (_isClick) _rotationSequence.Pause();
        else _rotationSequence.Play();
    }

    public void SetModelRotation(Vector3 rotate)
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x + rotate.y, transform.rotation.y - rotate.x, transform.rotation.z) * 0.5f);
    }

    public void SetModel(GameObject model)
    {
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        GameObject newModel = Instantiate(model, transform);
        newModel.transform.position = Vector3.zero;
    }
}
