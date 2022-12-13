using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Define;
using static Define.Player;


public class InventoryUIManager : MonoBehaviour
{
    private PlayerModeType _playerModeType;
    [SerializeField] private SkinListSO _skinList;

    // ¹ØÀÇ ¹öÆ° »ý¼º
    [SerializeField] private RectTransform _playerModeBtnParent;
    [SerializeField] private Button _playerModeBtn;


    // ÄÜÅÙÆ® »ý¼º
    [SerializeField] private GameObject _content;
    [SerializeField] private RectTransform _contentParent;

    [SerializeField] private GameObject _modelBtn;

    private Dictionary<PlayerModeType, GameObject> _contentDictionary = new Dictionary<PlayerModeType, GameObject>();


    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            SkinInfo skinInfo = _skinList._skinInfoList[i];

            GameObject newBtn = Instantiate(_playerModeBtn.gameObject, _playerModeBtnParent);
            newBtn.GetComponent<PlayerBtnInfo>().Init(this, GetPlayerModeType(i), skinInfo._modelList[0]._sprite);

            GameObject newContent = Instantiate(_content, _contentParent);
            _contentDictionary.Add(GetPlayerModeType(i), newContent);
            for (int j = 0; j < 5; j++)
            {
                GameObject newSkinBtn = Instantiate(_modelBtn, newContent.transform);
                newSkinBtn.GetComponent<ModelBtnInfo>().Init(this, skinInfo._modelList[j]);
            }
            newContent.SetActive(false);
        }

        _contentDictionary[PlayerModeType.CUBE].SetActive(true);
    }

    // ¹ØÀÇ ¹öÆ° ´­·¶À» ¶§
    public void SetInventory(PlayerModeType playerMode)
    {
        if (_contentDictionary.TryGetValue(_playerModeType, out GameObject value))
            value?.SetActive(false);
        _playerModeType = playerMode;
        if (_contentDictionary.TryGetValue(_playerModeType, out value))
            value?.SetActive(true);
    }

    public void SetMode(SkinSO skinSO)
    {
        Debug.Log(skinSO._modelTex);

        SkinInfo skinInfo = null;
        foreach (SkinInfo info in _skinList._skinInfoList)
        {
            if (info._playerModeType == skinSO._playerModeType)
            {
                skinInfo = info;
                break;
            }
        }

        Debug.Log(skinInfo?._model.name);
        skinInfo._currentModelTex = skinSO._modelTex;
    }
}
