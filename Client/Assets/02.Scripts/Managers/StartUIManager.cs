using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;


public enum UIPanelType
{
    NONE,
    INVENTORY,
    SETTING,
    CLOSE,
}

public class StartUIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _inventoryCanvasGroup;
    [SerializeField] private CanvasGroup _settingCanvasGroup;
    [SerializeField] private CanvasGroup _closeCanvasGroup;

    public UnityEvent _inventoryInit;
    public UnityEvent _settingInit;
    public UnityEvent _closeInit;

    private CanvasGroup _fadeImage;
    [SerializeField] private float _delay = 0.5f;


    private void Awake() => Init();

    void Init()
    {
        _fadeImage = GameManager.Instance.uiManager.FadeImage;
    }

    public void Exit()
    {
        Sequence seq = DOTween.Sequence();
        seq.OnRewind(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = true;
            _fadeImage.blocksRaycasts = true;
        });
        seq.Append(_fadeImage.DOFade(1f, _delay));
        seq.AppendCallback(() =>
        {
            _closeInit?.Invoke();
            _closeCanvasGroup.alpha = 1;
            _closeCanvasGroup.interactable = true;
            _closeCanvasGroup.blocksRaycasts = true;
        });
        seq.Append(_fadeImage.DOFade(0.0f, _delay));
        seq.OnComplete(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = false;
            _fadeImage.blocksRaycasts = false;
        });
        seq.Play();
    }

    public void ToMainPanel(string type)
    {
        Sequence seq = DOTween.Sequence();
        seq.OnRewind(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = true;
            _fadeImage.blocksRaycasts = true;
        });
        seq.Append(_fadeImage.DOFade(1f, _delay));
        seq.AppendCallback(() =>
        {
            if (type == UIPanelType.INVENTORY.ToString())
            {
                Debug.Log("Inventory 종료");
                _inventoryCanvasGroup.alpha = 0;
                _inventoryCanvasGroup.interactable = false;
                _inventoryCanvasGroup.blocksRaycasts = false;
            }
            else if (type == UIPanelType.SETTING.ToString())
            {
                Debug.Log("Setting 종료");
                _settingCanvasGroup.alpha = 0;
                _settingCanvasGroup.interactable = false;
                _settingCanvasGroup.blocksRaycasts = false;
            }
            else if (type == UIPanelType.CLOSE.ToString())
            {
                _closeCanvasGroup.alpha = 0;
                _closeCanvasGroup.interactable = false;
                _closeCanvasGroup.blocksRaycasts= false;
            }
        });
        seq.Append(_fadeImage.DOFade(0.0f, _delay));
        seq.OnComplete(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = false;
            _fadeImage.blocksRaycasts = false;
        });
        seq.Play();
    }

    public void ToInventoryPanel()
    {
        Sequence seq = DOTween.Sequence();
        seq.OnRewind(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = true;
            _fadeImage.blocksRaycasts = true;
        });
        seq.Append(_fadeImage.DOFade(1f, _delay));
        seq.AppendCallback(() =>
        {
            _inventoryInit?.Invoke();
            _inventoryCanvasGroup.alpha = 1;
            _inventoryCanvasGroup.interactable = true;
            _inventoryCanvasGroup.blocksRaycasts = true;
        });
        seq.Append(_fadeImage.DOFade(0.0f, _delay));
        seq.OnComplete(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = false;
            _fadeImage.blocksRaycasts = false;
        });
        seq.Play();
    }

    public void ToSettingPanel()
    {
        Sequence seq = DOTween.Sequence();
        seq.OnRewind(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = true;
            _fadeImage.blocksRaycasts = true;
        });
        seq.Append(_fadeImage.DOFade(1f, _delay));
        seq.AppendCallback(() =>
        {
            _settingInit?.Invoke();
            _settingCanvasGroup.alpha = 1;
            _settingCanvasGroup.interactable = true;
            _settingCanvasGroup.blocksRaycasts = true;
        });
        seq.Append(_fadeImage.DOFade(0.0f, _delay));
        seq.OnComplete(() =>
        {
            _fadeImage.alpha = 0;
            _fadeImage.interactable = false;
            _fadeImage.blocksRaycasts = false;
        });
        seq.Play();
    }
}
