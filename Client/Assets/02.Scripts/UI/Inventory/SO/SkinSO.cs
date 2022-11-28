using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New SkinSO", menuName ="SO/Inventory/Skin")]
public class SkinSO : ScriptableObject
{
    public int _index;
    public Mesh _model;
    public Sprite _sprite;
}
