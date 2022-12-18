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

    public Sprite GetSprite(int index)
    {
        return _skinInfoList[index]._modelList[0]._sprite;
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

