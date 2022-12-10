using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Trigger_Base : MonoBehaviour
{
    protected PlayerController _playerController;
    [SerializeField] private List<ObjectValue> _moveValue;
    [SerializeField] private List<ObjectValue> _rotateValue;
    protected Material _material;

    protected bool _isUse = false;


    private void Awake() => Init();
    void Init()
    {
        _material = transform.GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        StartCoroutine(ObjectMove());
        StartCoroutine(ObjectRotation());
    }
    // 오브젝트 이동 코드

    public IEnumerator ObjectMove()
    {
        foreach (ObjectValue value in _moveValue)
        {
            yield return new WaitForSeconds(value._delay);
            Tween tween = transform.DOMove(value._value, value._duration);
            yield return tween.WaitForCompletion();
        }
    }
    public IEnumerator ObjectRotation()
    {
        foreach (ObjectValue value in _rotateValue)
        {
            yield return new WaitForSeconds(value._delay);
            Tween tween = transform.DOMove(value._value, value._duration);
            yield return tween.WaitForCompletion();
        }
    }
    // 오브젝트 알파값 코드
    public IEnumerator FadeObject()
    {
        float degree = 0;
        while (true)
        {
            degree += Time.deltaTime;
            float alpha = Mathf.Sin(degree) / 2 + 0.5f;
            _material.SetFloat("_Alpha", alpha);

            yield return null;
        }
    }


    public void OnTrigger(PlayerController playerController)
    {
        if (_isUse) return;
        _playerController = playerController;
        _isUse = true;
        Trigger();
    }
    public abstract void Trigger();
}

[Serializable]
public class ObjectValue
{
    public Vector3 _value;

    public float _delay;
    public float _duration;
}