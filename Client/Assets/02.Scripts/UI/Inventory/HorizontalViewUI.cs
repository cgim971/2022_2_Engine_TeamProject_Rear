using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalViewUI : MonoBehaviour
{
    [SerializeField] private GameObject _slot;
    [SerializeField] private Transform _content;

    private List<SkinSO> _skinList;
    public List<SkinSO> SkinList
    {
        get => _skinList;
        set => _skinList = value;
    }

    private ScrollRect _verticalView;
    public ScrollRect VerticalView
    {
        get => _verticalView;
        set => _verticalView = value;
    }

    public void Init()
    {
        for (int i = 0; i < _skinList.Count; i++) CreateSlot(_skinList[i]);
    }

    void CreateSlot(SkinSO skin)
    {
        GameObject newSlot = Instantiate(_slot, _content);
        newSlot.GetComponent<SlotUI>().Skin = skin;
        newSlot.GetComponent<SlotUI>().HorizontalView = this.GetComponent<ScrollRect>();
        newSlot.GetComponent<SlotUI>().VerticalView = _verticalView;
        newSlot.GetComponent<SlotUI>().Init();
    }


}
