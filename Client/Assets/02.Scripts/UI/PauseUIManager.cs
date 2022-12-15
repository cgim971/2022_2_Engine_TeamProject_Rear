using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define.Sound;

public class PauseUIManager : MonoBehaviour
{
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _effectSlider;
    [SerializeField] private Slider _processSlider;
    [SerializeField] private Slider _processSliderA;

    private void Awake() => Init();

    public void Init()
    {
        float bgmVolume = PlayerPrefs.GetFloat(_bgmVolume, 1);
        float effectVolume = PlayerPrefs.GetFloat(_effectVolume, 1);

        _bgmSlider.value = bgmVolume;
        _effectSlider.value = effectVolume;
    }

    public void SetProcess()
    {
        _processSlider.maxValue = _processSliderA.maxValue;
        _processSlider.value = _processSliderA.value;
    }

    public void SliderValueChange(string slider)
    {
        if (slider == "BGM")
        {
            PlayerPrefs.SetFloat(_bgmVolume, _bgmSlider.value);
            SoundManager.SetBgmVolume();
        }
        else if (slider == "EFFECT") PlayerPrefs.SetFloat(_effectVolume, _effectSlider.value);
    }
}
