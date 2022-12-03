using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    private const float _initSpeed = 1f;
    [SerializeField] private float _speed = 1f;
    public float Speed => _speed;

    private void Start()
    {
        SetSpeed();
    }

    // To do : 속도 변경 오브젝트와 닿으면 속도 변경 그 외는 아직 고민
    public void SetSpeed(float speed = _initSpeed)
    {
        _speed = speed;
    }

}
