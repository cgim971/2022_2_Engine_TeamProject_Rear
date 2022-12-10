using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trigger_RotateObj : Trigger_Base
{
    [SerializeField] private List<ObjectValue> _rotateValue;

    public void Start() => StartCoroutine(ObjectRotation());

    public IEnumerator ObjectRotation()
    {   
        foreach (ObjectValue value in _rotateValue)
        {
            yield return new WaitForSeconds(value._delay);
            Tween tween = transform.DORotate(value._value, value._duration, RotateMode.FastBeyond360);
            yield return tween.WaitForCompletion();
        }
    }

    public override void Trigger() { }
     public override void OffTrigger() { }


}
