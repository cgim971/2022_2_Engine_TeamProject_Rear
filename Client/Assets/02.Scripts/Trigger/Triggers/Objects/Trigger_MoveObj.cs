using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trigger_MoveObj : Trigger_Base
{
    [SerializeField] private List<ObjectValue> _moveValue;

    public void Start() => StartCoroutine(ObjectMove());

    public IEnumerator ObjectMove()
    {
        foreach (ObjectValue value in _moveValue)
        {
            yield return new WaitForSeconds(value._delay);
            Tween tween = transform.DOMove(value._value, value._duration);
            yield return tween.WaitForCompletion();
        }
    }
    public override void Trigger() { }

    public override void OffTrigger() { }
}
