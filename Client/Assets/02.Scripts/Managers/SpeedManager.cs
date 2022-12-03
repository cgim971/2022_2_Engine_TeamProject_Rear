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

    // To do : �ӵ� ���� ������Ʈ�� ������ �ӵ� ���� �� �ܴ� ���� ���
    public void SetSpeed(float speed = _initSpeed)
    {
        _speed = speed;
    }

}
