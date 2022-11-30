using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement_Cube : PlayerMovement_Base
{
    float _xIndex = 0;
    float _yIndex = 0;
    float _zIndex = 0;

    Sequence _animationSeq = null;

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
        _xIndex++;
        Vector3 nextRotationValue = new Vector3(90 * _xIndex, 90 * _yIndex, 90 * _zIndex);

        Sequence seq = DOTween.Sequence();
        seq.Append(_modelTs.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f));
        seq.Append(_modelTs.DORotate(nextRotationValue, 0.3f).SetEase(Ease.Linear));
        seq.Join(_modelTs.DOScale(new Vector3(1f, 1f, 1f), 0.1f));
        seq.OnComplete(() => { });
    }

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
