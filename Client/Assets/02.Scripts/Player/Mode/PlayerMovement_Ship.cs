using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Ship : PlayerMovement_Base
{
    private Vector3 _upDir = Vector3.zero;

    public override void UseInit()
    {
        base.UseInit();
        StartCoroutine(OnClick());
    }

    public override void Move() => _rigidbody.MovePosition(_playerTs.position + (_dir + _upDir) * _speed * _speedManager.Speed * Time.deltaTime);
    public override void Jumping()
    {
        _rigidbody.velocity = Vector3.zero;
        _upDir = _customGravity.GravityValue.normalized * -1;

        _customGravity.IsGravity = false;
    }
    public void JumpingEnd()
    {
        _rigidbody.velocity = Vector3.zero;
        _upDir = Vector3.zero;

        _customGravity.IsGravity = true;
    }

    public override void Animation() { }

    public override IEnumerator OnClick()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Jumping();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            JumpingEnd();
            yield return new WaitForFixedUpdate();
        }
    }

}
