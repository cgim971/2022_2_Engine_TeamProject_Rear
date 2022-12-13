using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Define;
using static Define.Player;


public class InventoryUIManager : MonoBehaviour
{
    private PlayerModeType _playerModeType;

    [SerializeField] private RectTransform _content;
    [SerializeField] private Button _btn;

    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject newBtn = Instantiate(_btn.gameObject, _content);
            newBtn.GetComponent<ItemBtnInfo>().Init(this, GetPlayerModeType(i));
        }
    }

    public void SetInventory(PlayerModeType playerMode)
    {
        _playerModeType = playerMode;
    }
}
