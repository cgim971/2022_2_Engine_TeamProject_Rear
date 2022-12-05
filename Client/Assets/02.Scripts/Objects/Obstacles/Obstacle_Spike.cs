using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Obstacle_Spike : Obstacle_Base
{
    [SerializeField] private Vector3 _rot;

    private void Start()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DORotate(_rot, 2.5f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1));
        StartCoroutine(FadeObject());
    }

    public override void Effect() { }
}
