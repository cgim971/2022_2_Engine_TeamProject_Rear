using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectManager : MonoBehaviour
{
    // To do : ����Ʈ ȿ������ ���⼭ �ҷ����� ��
    // ����ٰ� �̸� �����ϰ� ��Ȱ��ȭ 
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
