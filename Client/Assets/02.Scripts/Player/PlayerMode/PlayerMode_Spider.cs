using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode_Spider : PlayerMode_Base
{
    [SerializeField] private float _maxDistance = 30f;
    private Vector3 _oppositeGroundPosition;

    public override void Animation()
    {
    }

    public override bool CanJump()
    {
        if (CheckOppositeGround())
        {
            Teleport();
            return true;
        }
        else if (CheckGround())
        {
            Jump();
            return true;
        }
        else if (_isExtraJump)
        {
            _isExtraJump = false;
            Jump();
            return true;
        }
        return false;

    }

    public override void Jump()
    {
        Animation();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_playerController.Gravity * _jumpPower * -1, ForceMode.VelocityChange);
    }

    public void Teleport()
    {
        _playerTs.position = _oppositeGroundPosition - (_playerController.Gravity * -1 * _sizeManager.Size.x);
        _playerController.ReverseGravity();
    }

    public bool CheckOppositeGround()
    {
        _oppositeGroundPosition = Vector3.zero;
        Ray ray = new Ray(_playerTs.position, _playerController.Gravity * -1);
        if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _groundLayerMask))
        {
            _oppositeGroundPosition = hit.point;

            return true;
        }

        return false;
    }
}
