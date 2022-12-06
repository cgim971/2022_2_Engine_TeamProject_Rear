using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameUIManager : MonoBehaviour
{

    [SerializeField] private Slider _processSlider;
    [SerializeField] private TextMeshProUGUI _tryText;

    private void Start()
    {
        _tryText.text = $"Attempt {GameManager.Instance.TryCount}";

        Sequence seq = DOTween.Sequence();
        seq.InsertCallback(1.5f, () => _tryText.gameObject.SetActive(false));

        // Stage info에다가 끝값을 넣을 예정
        _processSlider.maxValue = 100;
        _processSlider.value = 0;
        StartCoroutine(Process());
    }

    IEnumerator Process()
    {
        while (true)
        {
            yield return null;
            _processSlider.value += Time.deltaTime;

            if (_processSlider.value == _processSlider.maxValue) yield break;
        }
    }




}
