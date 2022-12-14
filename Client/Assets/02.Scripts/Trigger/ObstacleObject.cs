using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
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

    [ContextMenu("Trigger_Obstacle")]
    public void AddObstacle() => _triggerList.Add(gameObject.AddComponent<Trigger_Obstacle>());
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
}
