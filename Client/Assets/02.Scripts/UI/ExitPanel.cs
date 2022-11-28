using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class ExitPanel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _btn;
    private CanvasGroup _btnCanvasGroup;

    private string _ment = "Are you sure to off?";

    private int _fontSize = 160;

    public void Init()
    {
        _text.text = string.Empty;
        _text.fontSize = 140;

        _btnCanvasGroup = _btn.GetComponent<CanvasGroup>();

        _btnCanvasGroup.alpha = 0;
        _btnCanvasGroup.interactable = false;
        _btnCanvasGroup.blocksRaycasts = false;

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(0.5f);
        seq.Append(DOTween.To(() => _text.text, x => _text.text = x, _ment, 1.5f));
        seq.AppendCallback(() =>
        {
            _btnCanvasGroup.DOFade(1f, 0.3f);
            _btnCanvasGroup.interactable = true;
            _btnCanvasGroup.blocksRaycasts = true;
        });
        seq.Append(DOTween.To(() => _text.fontSize = 140, x => _text.fontSize = x, _fontSize, 1.5f).SetLoops(-1, LoopType.Yoyo));



        _btn.onClick.AddListener(() =>
        {
            Debug.Log("Á¾·á!");
            Application.Quit();
        });
    }


}
