using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeImage;
    public CanvasGroup FadeImage
    {
        get => _fadeImage;
        set => _fadeImage = value;
    }




}
