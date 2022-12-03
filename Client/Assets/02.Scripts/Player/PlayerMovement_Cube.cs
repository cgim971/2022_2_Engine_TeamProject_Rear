using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement_Cube : PlayerMovement_Base
{
    private Transform _gimbalLockTs;

    public override void UseInit()
    {
        base.UseInit();
        _gimbalLockTs = _modelTs.parent;
        SetGimbalLockObjectRotation();

        StartCoroutine(OnClick());
    }

    public override void Move() => _rigidbody.MovePosition(_playerTs.position + _dir * _speed * _speedManager.Speed * Time.deltaTime);
    public override void Jumping()
    {
        Animation();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_up * _jumpPower, ForceMode.VelocityChange);
    }

    public override void Animation()
    {

        Sequence seq = DOTween.Sequence();
        seq.Append(_modelTs.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.15f));
        seq.Join(_modelTs.DOLocalRotate(Vector3.right * 90f, 0.3f).SetEase(Ease.Linear));
        seq.AppendInterval(0.15f);
        seq.Join(_modelTs.DOScale(new Vector3(1f, 1f, 1f), 0.15f));
        seq.AppendCallback(() =>
        {
            _gimbalLockTs.rotation = _modelTs.transform.rotation;
            _modelTs.localRotation = Quaternion.identity;
        });
        seq.OnComplete(() => { });
    }

    public void SetGimbalLockObjectRotation()
    {
        if (_dir.x != 0) _gimbalLockTs.rotation = Quaternion.Euler(Vector3.up * 90 * _dir.x);
        else _gimbalLockTs.rotation = Quaternion.Euler(Vector3.zero);
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
        if (CheckGround() || ExtraJumpA())
        {
            Jumping();
        }
    }
    private bool ExtraJumpA()
    {
        if (_extraJump > 0)
        {
            _extraJump = 0;
            return true;
        }

        return false;
    }

    private bool CheckGround()
    {
        Ray ray = new Ray(transform.position, _customGravity.GravityValue);
        if (Physics.Raycast(ray, 0.6f/*수정 필요 길이 재고 밑까지 해야함*/, _groundLayerMask))
        {
            return true;
        }

        return false;
    }

}
