using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageInfo : MonoBehaviour
{
    private StageSO _stageSO;

    private Button _stageBtn;
    private Image _imageBackground;
    private Image _titleImage;
    private TextMeshProUGUI _titleText;
    private TextMeshProUGUI _producerText;
    private Slider _processSlider;
    private Image _sliderBackgroundImage;
    private Image _sliderFillImage;


    [SerializeField] private Material _uiBackgroundMat;
    [SerializeField] private Material _uiButtonMat;
    [SerializeField] private Material _uiSliderMat;
    [SerializeField] private Material _uiSliderBackgroundMat;

    private void Awake()
    {
        _stageBtn = GetComponent<Button>();
        _titleImage = transform.Find("Image").GetComponent<Image>();
        _imageBackground = transform.Find("ImageBackground").GetComponent<Image>();
        _processSlider = transform.Find("ProcessSlider").GetComponent<Slider>();
        _sliderBackgroundImage = _processSlider.transform.Find("Background").GetComponent<Image>();
        _sliderFillImage = _processSlider.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();

        _titleText = transform.Find("TitleText").GetComponent<TextMeshProUGUI>();
        _producerText = transform.Find("ProducerText").GetComponent<TextMeshProUGUI>();
    }

    public void Init(StageSO stageSO)
    {
        _stageSO = stageSO;

        if (!stageSO._isMain && !stageSO._isComming) _stageBtn.onClick.AddListener(() => GameManager.Instance.sceneManager.StageScene(stageSO));

        _titleImage.sprite = _stageSO._stageSprite;
        _titleText.text = $"{_stageSO._stageTitle}";
        _producerText.text = $"Made By {_stageSO._stageProducer}";

        OffPanel();
    }

    //// Test code
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        OnPanel();
    //    }
    //    else if(Input.GetKeyDown(KeyCode.D))
    //    {
    //        OffPanel();
    //    }
    //}

    public void OnPanel()
    {
        _imageBackground.material = _uiBackgroundMat;
        _sliderBackgroundImage.material = _uiSliderBackgroundMat;
        _sliderFillImage.material = _uiSliderMat;
    }
    public void OffPanel()
    {
        _imageBackground.material = null;
        _sliderBackgroundImage.material = null;
        _sliderFillImage.material = null;
    }

}
