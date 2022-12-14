using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransObject : MonoBehaviour
{

    [SerializeField] private List<Trigger_Base> _triggerList = new List<Trigger_Base>();
    private PlayerController _playerController;
    protected Collider _collider;

    private void Awake() => Init();
    void Init()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _collider = transform.GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    #region Trigger
    [ContextMenu("Trigger List Clear")]
    public void ClearList()
    {
        foreach (Trigger_Base trigger in _triggerList) DestroyImmediate(trigger);

        _triggerList.Clear();
    }

    [ContextMenu("Trigger_MoveObj")]
    public void AddMoveObj() => _triggerList.Add(gameObject.AddComponent<Trigger_MoveObj>());

    [ContextMenu("Trigger_RotateObj")]
    public void AddRotateObj() => _triggerList.Add(gameObject.AddComponent<Trigger_RotateObj>());

    [ContextMenu("Trigger_AlphaObj")]
    public void AddAlphaObj() => _triggerList.Add(gameObject.AddComponent<Trigger_AlphaObj>());

    [ContextMenu("Trigger_CameraObj")]
    public void AddCameraObj() => _triggerList.Add(gameObject.AddComponent<Trigger_CameraObj>());
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Trigger_Base trigger in _triggerList)
            {
                trigger.OnTrigger(_playerController);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Trigger_Base trigger in _triggerList)
            {
                trigger.OffTrigger();
            }
        }
    }
}
