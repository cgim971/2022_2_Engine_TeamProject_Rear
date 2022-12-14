using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trigger_MoveObj : Trigger_Base
{
    [SerializeField] private List<ObjectValue> _moveValue;
    [SerializeField] bool _isLoop = false;

    public void Start()
    {
        if (_isLoop)
            StartCoroutine(ObjectLoopMove());
        else
            StartCoroutine(ObjectMove());
    }
    public IEnumerator ObjectMove()
    {
        foreach (ObjectValue value in _moveValue)
        {
            yield return new WaitForSeconds(value._delay);
            Tween tween = transform.DOMove(value._value, value._duration);
            yield return tween.WaitForCompletion();
        }
    }
    public IEnumerator ObjectLoopMove()
    {
        int index = 0;
        ObjectValue value = _moveValue[index];
        while (true)
        {
            yield return new WaitForSeconds(value._delay);
            Tween tween = transform.DOMove(value._value, value._duration);
            yield return tween.WaitForCompletion();

            index++;
            if (index >= _moveValue.Count) index = 0;
            value = _moveValue[index];
        }
    }

    public override void Trigger() { }

    public override void OffTrigger() { }
}
