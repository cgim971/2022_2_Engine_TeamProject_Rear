using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class SceneManager : MonoBehaviour
{
    private string _nextScene;
    private CanvasGroup _loadingImage;
    private TextMeshProUGUI _loadingText;
    private string _loadingMent = "Loading...";

    private void Start()
    {
        _loadingImage = GameManager.Instance.uiManager.LoadingImage;
        _loadingText = GameManager.Instance.uiManager.LoadingText;
    }

    public static void LoadScene(string sceneName) => LoadScene(sceneName, LoadSceneMode.Single);

    public static void LoadScene(string sceneName, LoadSceneMode mode)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, mode);
    }

    public void LoadingScene(string sceneName)
    {
        _nextScene = sceneName;
        StartCoroutine(LoadingScene());
    }

    public void StageScene(string sceneName)
    {
        LoadingScene(sceneName);
    }

    IEnumerator LoadingScene()
    {
        yield return null;

        var seq = _loadingImage.DOFade(1f, 0.2f);
        yield return seq.WaitForCompletion();

        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_nextScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f)
            {

            }
            else
            {
                op.allowSceneActivation = true;
                _loadingImage.DOFade(0f, 0.2f);
                LoadScene("GameUI", UnityEngine.SceneManagement.LoadSceneMode.Additive);
                yield break;
            }
        }

    }


}
