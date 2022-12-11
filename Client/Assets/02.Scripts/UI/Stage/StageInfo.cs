using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageInfo : MonoBehaviour
{
    private StageSO _stageSO;

    private Button _stageBtn;
    private Image _titleImage;
    private TextMeshProUGUI _titleText;
    private TextMeshProUGUI _producerText;
    private Slider _processSlider;

    private void Awake()
    {
        _stageBtn = GetComponent<Button>();
        _stageBtn.onClick.AddListener(() => GameManager.Instance.sceneManager.LoadingScene("Stage_0"));
    }

    public void Init(StageSO stageSO)
    {
        _stageSO = stageSO;

        _titleImage.sprite = _stageSO._stageSprite;
        _titleText.text = $"{_stageSO._stageTitle}";
        _producerText.text = $"Made By {_stageSO._stageProducer}";
    }




}
