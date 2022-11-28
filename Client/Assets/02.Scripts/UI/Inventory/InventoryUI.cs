using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public enum SkinType
    {
        NONE,
        CUBE,
        UFO,
    }

    [SerializeField] private ScrollRect _verticalView;
    [SerializeField] private ScrollRect _horizontalView;
    [SerializeField] private Transform _content;

    [SerializeField] private SkinListSO _skinList;

    Dictionary<SkinType, GameObject> _horizontalViewDictionary = new Dictionary<SkinType, GameObject>();

    public void Init()
    {
        foreach (GameObject skin in _horizontalViewDictionary.Values)
        {
            Destroy(skin);
        }
        _horizontalViewDictionary.Clear();

        CreateSkin();
    }

    void CreateSkin()
    {
        CreateHorizontalView(SkinType.CUBE, _skinList._cubeList);
        CreateHorizontalView(SkinType.UFO, _skinList._ufoList);
    }

    void CreateHorizontalView(SkinType skinType, List<SkinSO> skinList)
    {
        GameObject newHorizontalView = Instantiate(_horizontalView.gameObject, _content.transform);
        newHorizontalView.GetComponent<HorizontalViewUI>().SkinList = skinList;
        newHorizontalView.GetComponent<HorizontalViewUI>().VerticalView = _verticalView;
        newHorizontalView.GetComponent<HorizontalViewUI>().Init();

        _horizontalViewDictionary.Add(skinType, newHorizontalView);
    }
}
