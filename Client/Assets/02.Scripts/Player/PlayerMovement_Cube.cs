using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Cube : PlayerMovement_Base
{
    public override void Move() => _rigidbody.MovePosition(this.gameObject.transform.position + _velocity * _speed * _speedManager.Speed * Time.deltaTime);

    public override void Jumping()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_up * _jumpPower, ForceMode.VelocityChange);
    }

    public override IEnumerator OnClick()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Jump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || CheckGround());
        }
    }

    private void Jump()
    {
        if (CanJump())
        {
            Jumping();
        }
    }
    private bool CanJump()
    {
        if (CheckGround() /*|| 추가 점프*/) return true;
        return false;
    }
    private bool CheckGround()
    {
        Ray ray = new Ray(transform.position, _customGravity.GravityValue);
        if (Physics.Raycast(ray, 0.6f, _groundLayerMask))
        {
            return true;
        }

        return false;
    }
}
