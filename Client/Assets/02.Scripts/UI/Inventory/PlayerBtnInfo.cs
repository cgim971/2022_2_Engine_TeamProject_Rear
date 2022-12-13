using Define;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBtnInfo : MonoBehaviour
{
    public void Init(InventoryUIManager inventoryUiManager, PlayerModeType playerMode, Sprite modelSprite)
    {
        this.GetComponent<Image>().sprite = modelSprite;
        this.GetComponent<Button>().onClick.AddListener(() => inventoryUiManager.SetInventory(playerMode));
    }
}
