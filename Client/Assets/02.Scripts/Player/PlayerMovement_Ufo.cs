using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement_Ufo : PlayerMovement_Base
{
    [SerializeField] private float _delay = 0.5f;

    public override void UseInit()
    {
        StartCoroutine(OnClick());
    }

    public override void Move() => _rigidbody.MovePosition(_playerTs.position + _velocity * _speed * _speedManager.Speed * Time.deltaTime);
    public override void Jumping()
    {
        Event_Jump?.Invoke();
        Animation();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_up * _jumpPower, ForceMode.VelocityChange);
    }

    public override void Animation()
    {

    }

    public override IEnumerator OnClick()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            Jumping();
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
            yield return new WaitForFixedUpdate();
        }
    }
}
