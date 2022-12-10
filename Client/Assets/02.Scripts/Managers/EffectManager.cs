using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectManager : MonoBehaviour
{
    // To do : 이펙트 효과등을 여기서 불러오게 함
    // 여기다가 미리 생성하고 비활성화 
    public static EffectManager Instance => _instance;
    private static EffectManager _instance;

    public UnityEvent Event_DeathEffect;
    [SerializeField] private Transform _playerTs;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void OnDeath()
    {
        Event_DeathEffect?.Invoke();
    }

    public void DeathEffect()
    {

    }
}
