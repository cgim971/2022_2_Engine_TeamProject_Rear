using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkinType
{
    NONE,
    CUBE,
    UFO,
}

public class InventoryUI : MonoBehaviour
{
    private static InventoryUI _instance;
    public static InventoryUI Instance => _instance;

    [SerializeField] private ScrollRect _verticalView;
    [SerializeField] private ScrollRect _horizontalView;
    [SerializeField] private Transform _content;
    [SerializeField] private PreviewModel _previewModel;
    public PreviewModel PreviewModel => _previewModel;

    [SerializeField] private SkinListSO _skinList;
    [SerializeField] private SkinSO _initialSkin;
    Dictionary<SkinType, GameObject> _horizontalViewDictionary = new Dictionary<SkinType, GameObject>();

    public void Init()
    {
        _instance = this;

        foreach (GameObject skin in _horizontalViewDictionary.Values)
        {
            Destroy(skin);
        }
        _horizontalViewDictionary.Clear();

        CreateSkin();

        SkinSO _skin = null;
        if (_skinList._lastSkin != null)
        {
            _skin = _skinList._lastSkin;
        }
        else
        {
            _skin = _initialSkin;
        }

        _previewModel.SetModel(_skin._model);
    }

    void CreateSkin()
    {
        CreateHorizontalView(SkinType.CUBE, _skinList._cubeList);
        CreateHorizontalView(SkinType.UFO, _skinList._ufoList);
    }

    void CreateHorizontalView(SkinType skinType, List<SkinSO> skinList)
    {
        GameObject newHorizontalView = Instantiate(_horizontalView.gameObject, _content.transform);
        newHorizontalView.GetComponent<HorizontalViewUI>().SkinType = skinType;
        newHorizontalView.GetComponent<HorizontalViewUI>().SkinList = skinList;
        newHorizontalView.GetComponent<HorizontalViewUI>().VerticalView = _verticalView;
        newHorizontalView.GetComponent<HorizontalViewUI>().Init();

        _horizontalViewDictionary.Add(skinType, newHorizontalView);
    }

    public void SetCurrentSkin(SkinType skinType, SkinSO skinSO)
    {
        if (skinType == SkinType.CUBE)
        {
            _skinList._currentCube = skinSO;
        }
        else if (skinType == SkinType.UFO)
        {
            _skinList._currentUfo = skinSO;
        }

        _skinList._lastSkin = skinSO;
    }
}
