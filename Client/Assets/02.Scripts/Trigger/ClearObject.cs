using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClearObject : MonoBehaviour
{
    private PlayerController _playerController;
    private Collider _collider;

    public UnityEvent OnClear;

    private void Awake() => Init();
    void Init()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _collider = transform.GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnClear?.Invoke();
        }
    }

}
