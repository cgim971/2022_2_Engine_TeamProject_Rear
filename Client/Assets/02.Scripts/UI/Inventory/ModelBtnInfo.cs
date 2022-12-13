using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelBtnInfo : MonoBehaviour
{
    [SerializeField] private Image _image;
    public void Init(InventoryUIManager inventoryManager, SkinSO skinSO)
    {
        _image.sprite = skinSO._sprite;

        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (skinSO._lock == false)
                inventoryManager.SetMode(skinSO);
        });
    }

}
