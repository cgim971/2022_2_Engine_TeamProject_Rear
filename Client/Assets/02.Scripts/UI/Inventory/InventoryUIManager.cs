using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Define;
using static Define.Player;


public class InventoryUIManager : MonoBehaviour
{
    private PlayerModeType _playerModeType;

    [SerializeField] private RectTransform _btnParent;
    [SerializeField] private Button _btn;

    [SerializeField] private ScrollRect _modelScrollRect;
    [SerializeField] private GameObject _content;
    [SerializeField] private RectTransform _contentParent;
    private Dictionary<PlayerModeType, RectTransform> _contentDictionary = new Dictionary<PlayerModeType, RectTransform>();


    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject newBtn = Instantiate(_btn.gameObject, _btnParent);
            newBtn.GetComponent<ItemBtnInfo>().Init(this, GetPlayerModeType(i));

            GameObject newContent = Instantiate(_content, _contentParent);
            _contentDictionary.Add(GetPlayerModeType(i), newContent.GetComponent<RectTransform>());
        }

        _modelScrollRect.content = _contentDictionary[GetPlayerModeType(0)];
    }

    public void SetInventory(PlayerModeType playerMode)
    {
        _playerModeType = playerMode;
    }




}
