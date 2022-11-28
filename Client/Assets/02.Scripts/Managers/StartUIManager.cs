using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;


public enum UIPanelType
{
    NONE,
    INVENTORY,
    SETTING,
}

public class StartUIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _inventoryCanvasGroup;
    [SerializeField] private CanvasGroup _settingCanvasGroup;

    public UnityEvent _inventoryInit;
    public UnityEvent _settingInit;

    private void Awake() => Init();

    void Init() { }

    public void Exit()
    {
        Debug.Log("나감");
    }

    public void ToMainPanel(string type)
    {
        Debug.Log("메인화면으로");

        if (type == UIPanelType.INVENTORY.ToString())
        {
            Debug.Log("Inventory 종료");
            _inventoryCanvasGroup.alpha = 0;
            _inventoryCanvasGroup.interactable = false;
            _inventoryCanvasGroup.blocksRaycasts = false;
        }
        else if (type == UIPanelType.SETTING.ToString())
        {
            Debug.Log("Setting 종료");
            _settingCanvasGroup.alpha = 0;
            _settingCanvasGroup.interactable = false;
            _settingCanvasGroup.blocksRaycasts = false;
        }
    }

    public void ToInventoryPanel()
    {
        _inventoryInit?.Invoke();
        _inventoryCanvasGroup.alpha = 1;
        _inventoryCanvasGroup.interactable = true;
        _inventoryCanvasGroup.blocksRaycasts = true;
    }

    public void ToSettingPanel()
    {
        _settingInit?.Invoke();
        _settingCanvasGroup.alpha = 1;
        _settingCanvasGroup.interactable = true;
        _settingCanvasGroup.blocksRaycasts = true;
    }

}
