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

    private bool _isDead;
    public void SetIsDead(bool isDead) => _isDead = isDead;

    private void Start()
    {
        _uiManager = GameManager.Instance.uiManager;
        _fadeImage = _uiManager.FadeImage;
        _uiManager.OffCanvasGroup(_fadeImage);

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
                _processSlider.value += Time.deltaTime;
                
                if (_processSlider.value > _stageSO._processSliderValue)
                {
                    _stageSO._processSliderValue = _processSlider.value;
                }

                if(_isDead == true)
                {
                    yield break;
                }
            }
            else
            {
                Debug.Log("Clear");
                yield break;
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
            _pauseCanvsGroup.GetComponent<PauseUIManager>().SetProcess();
            Time.timeScale = 0;
            SoundManager.BgmPause();

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
            Time.timeScale = 1;
            SoundManager.BgmUnPause();
        });
        seq.Play();
    }

    public void OnClear()
    {
        Sequence seq = DOTween.Sequence().SetUpdate(true);
        seq.AppendCallback(() =>
        {
            _uiManager.InitCanvasGroup(_fadeImage);
            _uiManager.OffCanvasGroup(_gamingCanvasGroup);
        });
        seq.Append(_fadeImage.DOFade(1, _delay));
        seq.AppendCallback(() =>
        {
            _uiManager.OnCanvasGroup(_clearCanvsGroup);
        });
        seq.Append(_fadeImage.DOFade(0, _delay));
        seq.OnComplete(() =>
        {
            _uiManager.OffCanvasGroup(_fadeImage);
        });
        seq.Play();
    }

    public void ToStart()
    {
        // 수정 : 페이드 
        _uiManager.InitCanvasGroup(_fadeImage);
        Time.timeScale = 1;
        GameManager.Instance.sceneManager.LoadingScene("StartUI");
    }

    public void RetryStage()
    {
        _uiManager.InitCanvasGroup(_fadeImage);
        Time.timeScale = 1;
        GameManager.Instance.sceneManager.StageScene();
    }
}
