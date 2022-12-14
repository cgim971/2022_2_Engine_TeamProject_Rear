using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
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

    #region Trigger Object
    [ContextMenu("Trigger_JumpRing")]
    public void AddJumpRing() => _triggerList.Add(gameObject.AddComponent<Trigger_JumpRing>());

    [ContextMenu("Trigger_JumpStool")]
    public void AddJumpStool() => _triggerList.Add(gameObject.AddComponent<Trigger_JumpStool>());
    #endregion

    #region Portal Trigger
    [ContextMenu("Portal_ChangeDirection")]
    public void AddChangeDirection() => _triggerList.Add(gameObject.AddComponent<Trigger_Portal_ChangeDirection>());

    [ContextMenu("Portal_ChangeGravity")]
    public void AddChangeGravity() => _triggerList.Add(gameObject.AddComponent<Trigger_Portal_ChangeGravity>());

    [ContextMenu("Portal_ChangeSize")]
    public void AddChangeSize() => _triggerList.Add(gameObject.AddComponent<Trigger_Portal_ChangeSize>());

    [ContextMenu("Portal_ChangeSpeed")]
    public void AddChangeSpeed() => _triggerList.Add(gameObject.AddComponent<Trigger_Portal_ChangeSpeed>());

    [ContextMenu("Portal_Teleport")]
    public void AddTeleport() => _triggerList.Add(gameObject.AddComponent<Trigger_Portal_Teleport>());

    [ContextMenu("Portal_ChangeMode")]
    public void AddChangeMode() => _triggerList.Add(gameObject.AddComponent<Trigger_Portal_ChangeMode>());
    #endregion
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
            foreach(Trigger_Base trigger in _triggerList)
            {
                trigger.OffTrigger();
            }
        }
    }

}
