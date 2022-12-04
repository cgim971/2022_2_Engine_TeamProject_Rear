using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;

public class Object_TransMode : Object_Base
{
    [SerializeField] private PlayerModeType _playerMode;

    public override void OnEffect(PlayerMovement_Base player)
    {
        player.PlayerController.SetPlayerMode(_playerMode);
        Effect();
    }
    public override void OffEffect(PlayerMovement_Base player) { }
    public override void Effect() { }
}
