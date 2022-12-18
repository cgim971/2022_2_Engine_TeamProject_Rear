using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

[CreateAssetMenu(fileName = "New SkinList", menuName = "SO/List/SkinList")]
public class SkinListSO : ScriptableObject
{
    public List<SkinInfo> _skinInfoList;

    public void Init()
    {
        foreach (SkinInfo skinInfo in _skinInfoList)
        {
            skinInfo.Init();
        }
    }

    public void Init(List<SkinValue> skinValueList)
    {
        int index = 0;

        foreach (SkinInfo skinInfo in _skinInfoList)
        {
            skinInfo._currentModelTex = skinValueList[index]._currentTextures;
            int count = 0;
            foreach (SkinSO skin in skinInfo._modelList)
            {
                if (skinValueList[index]._lockList.Count <= count)
                {
                    skinValueList[index]._lockList.Add(true);
                }
                skin._lock = skinValueList[index]._lockList[count];
                count++;
            }
            index++;
        }
    }
    public Sprite GetSprite(int index) => _skinInfoList[index]._modelList[0]._sprite;

    public void Save()
    {
        List<SkinValue> skinValues = new List<SkinValue>();
        foreach (SkinInfo skinInfo in _skinInfoList)
        {
            List<bool> lockValues = new List<bool>();
            SkinValue skinValue = new SkinValue();
            skinValue._currentTextures = skinInfo._currentModelTex;
            for (int i = 0; i < skinInfo._modelList.Count; i++)
            {
                lockValues.Add(skinInfo._modelList[i]._lock);
            }
            skinValue._lockList = lockValues;
            skinValues.Add(skinValue);
        }
        GameManager.Instance.saveManager.SetSkinValue(skinValues);
    }
}

[System.Serializable]
public class SkinInfo
{
    public PlayerModeType _playerModeType;
    public GameObject _model;
    public Material _modelMat;
    public Texture _currentModelTex;
    public List<SkinSO> _modelList;

    public void Init()
    {
        _modelMat.SetTexture("_MainTex", _currentModelTex);
    }
}

