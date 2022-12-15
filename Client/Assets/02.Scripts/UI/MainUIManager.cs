using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.uiManager.OffCanvasGroup(GameManager.Instance.uiManager.FadeImage);
    }
}
