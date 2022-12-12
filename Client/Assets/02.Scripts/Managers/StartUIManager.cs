using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    // 인벤토리, 설정 
    [SerializeField] private CanvasGroup _inventoryCanvasGroup = null;
    [SerializeField] private CanvasGroup _settingCanvasGroup = null;
    [SerializeField] private CanvasGroup _informationCanvasGroup = null;
    [SerializeField] private CanvasGroup _rankCanvasGroup = null;

    private CanvasGroup _fadeImage = null;
    private UIManager _uiManager = null;
    [SerializeField] private float _delay = 0.2f;

    private void Start()
    {
        _uiManager = GameManager.Instance.uiManager;
        _fadeImage = _uiManager.FadeImage;

        _uiManager.OffCanvasGroup(_inventoryCanvasGroup);
        _uiManager.OffCanvasGroup(_settingCanvasGroup);
        _uiManager.OffCanvasGroup(_informationCanvasGroup);
        _uiManager.OffCanvasGroup(_rankCanvasGroup);
    }

    public void OnInventory()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OnCanvasGroup(_inventoryCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }
    public void OffInventory()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OffCanvasGroup(_inventoryCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }

    public void OnSetting()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OnCanvasGroup(_settingCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }
    public void OffSetting()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OffCanvasGroup(_settingCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }

    public void OnInformation()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OnCanvasGroup(_informationCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }
    public void OffInformation()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OffCanvasGroup(_informationCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }

    public void OnRank()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OnCanvasGroup(_rankCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }
    public void OffRank()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() => _uiManager.OffCanvasGroup(_rankCanvasGroup));
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }


    public void Quit()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.OnComplete(() =>
        {
            Application.Quit();
        });
        seq.Play();

    }


}
