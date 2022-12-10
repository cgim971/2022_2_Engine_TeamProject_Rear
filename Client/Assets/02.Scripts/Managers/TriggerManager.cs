using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{

    public static TriggerManager Instance => _instance;
    private static TriggerManager _instance;

    public UnityEvent Event_Death;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void OnDeath()
    {
        Event_Death?.Invoke();
    }

    IEnumerator Death()
    {
        yield return null;
    }
}
