using Define;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBtnInfo : MonoBehaviour
{
    [SerializeField] private Image _image; 
    public void Init(InventoryUIManager inventoryUiManager, PlayerModeType playerMode, Sprite modelSprite)
    {
        _image.sprite = modelSprite;
        this.GetComponent<Button>().onClick.AddListener(() => inventoryUiManager.SetInventory(playerMode));
    }
}
