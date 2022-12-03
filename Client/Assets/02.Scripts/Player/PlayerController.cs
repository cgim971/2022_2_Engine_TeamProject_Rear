using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    private CustomGravity _customGravity;
    public CustomGravity CustomGravity => _customGravity;

    private SpeedManager _speedManager;
    public SpeedManager SpeedManager => _speedManager;

    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;

    private Transform _followObjTs;
    public Transform FollowObjTs => _followObjTs;

    private void Awake() => Init();

    void Init()
    {
        _customGravity = GetComponent<CustomGravity>();
        _speedManager = GetComponent<SpeedManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _followObjTs = transform?.Find("FollowObject");
    }

    public void SetFollowObj(Vector3 newPos, Vector3 newRot)
    {
        // To do : 카메라가 회전 부드럽게 플레이어를 중심으로 돌면서
        _followObjTs.DOLocalMove(newPos, 1f);
        _followObjTs.DORotate(newRot, 1f);
    }

}
