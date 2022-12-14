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

    [SerializeField] private CanvasGroup _gamingCanvasGroup;
    [SerializeField] private CanvasGroup _pauseCanvsGroup;
    [SerializeField] private CanvasGroup _clearCanvsGroup;

    [SerializeField] private TextMeshProUGUI _tryText;
    [SerializeField] private TextMeshProUGUI _titleText;

    private UIManager _uiManager;
    private CanvasGroup _fadeImage;

    [SerializeField] private float _delay;

    private void Start()
    {
        _uiManager = GameManager.Instance.uiManager;
        _fadeImage = _uiManager.FadeImage;
        _titleText.text = GameManager.Instance.CurrentStageSO._stageTitle;
        Init(GameManager.Instance.CurrentStageSO);
    }

    public void Init(StageSO stageSO)
    {
        _stageSO = stageSO;
        _processSlider.maxValue = _stageSO._processSliderMaxValue;
        _processSlider.value = 0;
        _tryText.text = $"Attempt {GameManager.Instance.TryCount}";

        _uiManager.OffCanvasGroup(_pauseCanvsGroup);
        _uiManager.OnCanvasGroup(_gamingCanvasGroup);

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

    public void OnPause()
    {
        Sequence seq = DOTween.Sequence().SetUpdate(true);
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
            _uiManager.OffCanvasGroup(_gamingCanvasGroup);
            Time.timeScale = 0;
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() =>
        {
            _uiManager.OnCanvasGroup(_pauseCanvsGroup);
        });
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }

    public void OffPause()
    {
        Sequence seq = DOTween.Sequence().SetUpdate(true);
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
            Time.timeScale = 1;
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() =>
        {
            _uiManager.OffCanvasGroup(_pauseCanvsGroup);
        });
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
            _uiManager.OnCanvasGroup(_gamingCanvasGroup);
        });
        seq.Play();
    }

    public void ToStart()
    {
        SceneManager.LoadScene("StartUI");
    }

    public void RetryStage()
    {
        GameManager.Instance.sceneManager.StageScene();
    }
}
