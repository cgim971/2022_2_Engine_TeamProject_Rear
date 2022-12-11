using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeImage;
    public CanvasGroup FadeImage
    {
        get => _fadeImage;
        set => _fadeImage = value;
    }

    [SerializeField] private CanvasGroup _loadingImage;
    public CanvasGroup LoadingImage
    {
        get => _loadingImage;
        set => _loadingImage = value;
    }

    [SerializeField] private TextMeshProUGUI _loadingText;
    public TextMeshProUGUI LoadingText => _loadingText;

    public void OnCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void InitCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0.0f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void OffCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0.0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
