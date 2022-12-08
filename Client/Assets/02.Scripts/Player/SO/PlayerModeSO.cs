using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

[CreateAssetMenu(fileName ="New PlayerMode", menuName ="SO/PlayerMode")]
public class PlayerModeSO : ScriptableObject
{
    public PlayerModeType _modeType;
    public float _speed;
    public float _gravity;
}
