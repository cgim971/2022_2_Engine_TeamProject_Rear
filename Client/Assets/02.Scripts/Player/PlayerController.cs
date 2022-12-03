using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CustomGravity _customGravity;
    public CustomGravity CustomGravity => _customGravity;

    private SpeedManager _speedManager;
    public SpeedManager SpeedManager => _speedManager;

    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;

    private Transform _followCamTs;
    public Transform FollowCamTs => _followCamTs;

    private void Awake() => Init();

    void Init()
    {
        _customGravity = GetComponent<CustomGravity>();
        _speedManager = GetComponent<SpeedManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _followCamTs = transform.Find("FollowCam");
    }

    public void FollowCam(Vector3 newPos, Vector3 newRot)
    {
        _followCamTs.position = newPos;
        _followCamTs.rotation = Quaternion.Euler(newRot);
    }
}
