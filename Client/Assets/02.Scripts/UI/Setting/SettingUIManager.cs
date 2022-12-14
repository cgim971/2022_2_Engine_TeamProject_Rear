using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define.Sound;
public class SettingUIManager : MonoBehaviour
{
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _effectSlider;

    private void Awake() => Init();

    public void Init()
    {
        float bgmVolume = PlayerPrefs.GetFloat(_bgmVolume, 1);
        float effectVolume = PlayerPrefs.GetFloat(_effectVolume, 1);

        _bgmSlider.value = bgmVolume;
        _effectSlider.value = effectVolume;
    }
    public void SliderValueChange(string slider)
    {
        if (slider == "BGM")
        {
            PlayerPrefs.SetFloat(_bgmVolume, _bgmSlider.value);
        }
        else if (slider == "EFFECT") PlayerPrefs.SetFloat(_effectVolume, _effectSlider.value);
    }
}
