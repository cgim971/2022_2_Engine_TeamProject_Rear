using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager Instance => _instance;
    private static TriggerManager _instance;

    public UnityEvent Event_Death;
    public UnityEvent Event_Clear;
    public UnityEvent Event_ClearPanel;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void OnDeath()
    {
        Event_Death?.Invoke();
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.8f);
        GameManager.Instance.sceneManager.StageScene();

    }

    public void OnClear()
    {
        Event_Clear?.Invoke();
        StartCoroutine(Clear());
    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(0.8f);
        Event_ClearPanel?.Invoke();
    }
}
