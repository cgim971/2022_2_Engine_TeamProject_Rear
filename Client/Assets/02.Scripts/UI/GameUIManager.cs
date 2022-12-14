using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameUIManager : MonoBehaviour
{

    [SerializeField] private StageSO _stageSO;
    [SerializeField] private Slider _processSlider;
    [SerializeField] private CanvasGroup _settingCanvsGroup;
    [SerializeField] private TextMeshProUGUI _tryText;

    private UIManager _uiManager;
    private CanvasGroup _fadeImage;

    [SerializeField] private float _delay;

    private void Start()
    {
        Init(GameManager.Instance.CurrentStageSO);
        _uiManager = GameManager.Instance.uiManager;
        _fadeImage = _uiManager.FadeImage;
    }

    public void Init(StageSO stageSO)
    {
        _stageSO = stageSO;
        _processSlider.maxValue = _stageSO._processSliderMaxValue;
        _processSlider.value = 0;
        _tryText.text = $"Attempt {GameManager.Instance.TryCount}";

        OffSetting();

        Sequence seq = DOTween.Sequence();
        seq.OnRewind(() =>
        {
            _tryText.gameObject.SetActive(true);
            _tryText.DOFade(1f, 0f);
        });
        seq.AppendCallback(() =>
        {
            _tryText.DOFade(0f, 0.8f);
        });
        seq.Play();

        StartCoroutine(StageProcess());
    }

    IEnumerator StageProcess()
    {
        while (true)
        {
            yield return null;
            if (_processSlider.maxValue > _processSlider.value)
            {
                _processSlider.value += 1f;
                if (_processSlider.value > _stageSO._processSliderValue)
                {
                    _stageSO._processSliderValue = _processSlider.value;
                }
                yield return new WaitForSeconds(1f);
            }
            else
            {
                Debug.Log("Clear");
            }
        }
    }

    public void OnSetting()
    {
        Sequence seq = DOTween.Sequence();
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() =>
        {
            _uiManager.OnCanvasGroup(_settingCanvsGroup);
            PlayerController.Instance.TimeStop();
        });
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
        seq.AppendCallback(() =>
        {
            _uiManager.OffCanvasGroup(_settingCanvsGroup);
            PlayerController.Instance.TimePlay();
        });
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }
}
