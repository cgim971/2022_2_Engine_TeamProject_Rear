using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkinList", menuName = "SO/List/SkinList")]
public class SkinListSO : ScriptableObject
{
    public List<SkinSO> _cubeList;
    public List<SkinSO> _ufoList;
}
