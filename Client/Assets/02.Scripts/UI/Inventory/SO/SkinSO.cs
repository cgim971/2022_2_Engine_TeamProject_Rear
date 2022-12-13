using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

[CreateAssetMenu(fileName = "New SkinSO", menuName = "SO/Inventory/Skin")]
public class SkinSO : ScriptableObject
{
    public bool _lock;
    public PlayerModeType _playerModeType;

    public Sprite _sprite;
    public Texture _modelTex;
}
