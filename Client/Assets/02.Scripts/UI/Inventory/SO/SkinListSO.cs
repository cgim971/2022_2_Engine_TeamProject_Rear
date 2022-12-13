using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

[CreateAssetMenu(fileName = "New SkinList", menuName = "SO/List/SkinList")]
public class SkinListSO : ScriptableObject
{
    public List<SkinInfo> _skinInfoList;

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
    public Texture _currentModelTex;
    public List<SkinSO> _modelList;
}
