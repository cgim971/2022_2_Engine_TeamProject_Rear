using Define;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtnInfo : MonoBehaviour
{
    [SerializeField] private Image _image;
    public void Init(InventoryUIManager inventoryUiManager, PlayerModeType playerMode)
    {
        GetComponent<Button>().onClick.AddListener(() => inventoryUiManager.SetInventory(playerMode));
    }

}
