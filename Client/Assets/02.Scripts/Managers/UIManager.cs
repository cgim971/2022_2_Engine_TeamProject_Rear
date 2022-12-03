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
}
