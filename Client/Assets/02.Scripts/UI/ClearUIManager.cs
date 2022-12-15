using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClearUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _attemptText;
    [SerializeField] private TextMeshProUGUI _timeText;

    public void OnClear()
    {
        _titleText.text = $"{GameManager.Instance.CurrentStageSO._stageTitle} Complete!";
        _attemptText.text = $"Attempts : {GameManager.Instance.TryCount - 1}";
        _timeText.text = $"Time : ";
    }

    public void Retry()
    {
        GameManager.Instance.uiManager.InitCanvasGroup(GameManager.Instance.uiManager.FadeImage);
        GameManager.Instance.sceneManager.StageScene(GameManager.Instance.CurrentStageSO);
    }

}
