using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelBtnInfo : MonoBehaviour
{
    [SerializeField] private Image _image;
    private SkinSO _skinSO;
    private InventoryUIManager _inventoryUIManager;

    public void Init(InventoryUIManager inventoryManager, SkinSO skinSO)
    {
        _skinSO = skinSO;
        _inventoryUIManager = inventoryManager;

        _image.sprite = _skinSO._sprite;

        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (_skinSO._lock == false)
                _inventoryUIManager.SetMode(_skinSO);
        });
    }

    public void OpenLock()
    {
        _skinSO._lock = false;
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (_skinSO._lock == false)
                _inventoryUIManager.SetMode(_skinSO);
        });
    }
}
