using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New SkinSO", menuName ="SO/Inventory/Skin")]
public class SkinSO : ScriptableObject
{
    public int _index;
    public GameObject _model;
    public Sprite _sprite;
}
