using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Trigger_Base : MonoBehaviour
{
    protected PlayerController _playerController;
    protected Material _material;

    protected bool _isUse = false;

    private void Awake() => Init();
    void Init()
    {
        _material = transform.GetComponent<MeshRenderer>().material;
    }

    public void OnTrigger(PlayerController playerController)
    {
        if (_isUse) return;
        _playerController = playerController;
        _isUse = true;
        Trigger();
    }
    public abstract void Trigger();
    public abstract void OffTrigger();
}

[Serializable]
public class ObjectValue
{
    public Vector3 _value;

    public float _delay;
    public float _duration;
}