using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkinList", menuName = "SO/List/SkinList")]
public class SkinListSO : ScriptableObject
{
    public SkinSO _lastSkin;

    public SkinSO _currentCube;
    public List<SkinSO> _cubeList;

    public SkinSO _currentShip;
    public List<SkinSO> _shipList;

    public SkinSO _currentUfo;
    public List<SkinSO> _ufoList;

    public SkinSO _currentWave;
    public List<SkinSO> _waveList;

    public SkinSO _currentRobot;
    public List<SkinSO> _robotList;

    public SkinSO _currentSpider;
    public List<SkinSO> _spiderList;

    public SkinSO _currentBall;
    public List<SkinSO> _ballList;
}
