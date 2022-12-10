using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    [SerializeField] private List<Trigger_Base> _triggerList = new List<Trigger_Base>();
    private PlayerController _playerController;

    private void Awake() => Init();
    void Init()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    [ContextMenu("Trigger List Clear")]
    public void ClearList()
    {
        _triggerList.Clear();
    }

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

}
