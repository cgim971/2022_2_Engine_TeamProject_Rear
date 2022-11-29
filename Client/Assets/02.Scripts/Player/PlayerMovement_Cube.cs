using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Cube : PlayerMovement_Base
{
    public override void UseInit() { }

    public override void Move() => _rigidbody.MovePosition(this.gameObject.transform.position + _velocity * _speed * _speedManager.Speed * Time.deltaTime);

    public override void Jumping()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_up * _jumpPower, ForceMode.VelocityChange);
    }

    public override void Animation() { }


    public override IEnumerator OnClick()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            CanJump();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || CheckGround());
            yield return new WaitForFixedUpdate();
        }
    }

    private void CanJump()
    {
        if (CheckGround())
        {
            Event_Jump?.Invoke();
            Jumping();
        }
    }

    private bool CheckGround()
    {
        Ray ray = new Ray(transform.position, _customGravity.GravityValue);
        if (Physics.Raycast(ray, 0.6f/*수정 필요 길이 재고 밑까지 해야함*/, _groundLayerMask))
        {
            return true;
        }
        else if (_extraJump > 0)
        {
            _extraJump = 0;
            return true;
        }

        return false;
    }

}
