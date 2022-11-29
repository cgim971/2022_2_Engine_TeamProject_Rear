using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkinList", menuName = "SO/List/SkinList")]
public class SkinListSO : ScriptableObject
{
    public SkinSO _lastSkin;

    public SkinSO _currentCube;
    public List<SkinSO> _cubeList;

    public SkinSO _currentUfo;
    public List<SkinSO> _ufoList;
}
