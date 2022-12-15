using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ClearObject : MonoBehaviour
{
    private PlayerController _playerController;
    private Collider _collider;
    [SerializeField] private Transform _targetTs;

    public UnityEvent Event_Clear;

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
            Event_Clear?.Invoke();

            Sequence seq = DOTween.Sequence();
            seq.Append(_playerController.transform.DOMove(_targetTs.position, 2f));
            seq.AppendInterval(1.8f);
            seq.AppendCallback(() => _playerController.transform.gameObject.SetActive(false));

        }
    }


}
