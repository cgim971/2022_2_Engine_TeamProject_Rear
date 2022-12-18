using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelBtnInfo : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _lockImage;
    private SkinSO _skinSO;
    private InventoryUIManager _inventoryUIManager;

    public void Init(InventoryUIManager inventoryManager, SkinSO skinSO)
    {
        _skinSO = skinSO;
        _inventoryUIManager = inventoryManager;

        _image.sprite = _skinSO._sprite;
        if (_skinSO._lock)
        {
            _image.gameObject.SetActive(false);
            _lockImage.gameObject.SetActive(true);
        }
        else
        {
            _image.gameObject.SetActive(true);
            _lockImage.gameObject.SetActive(false);
        }

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
