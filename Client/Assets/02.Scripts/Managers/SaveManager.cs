using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    [SerializeField] SkinListSO _skinList;
    [SerializeField] StageListSO _stageList;
    public SkinListSO SkinList => _skinList;
    public StageListSO StageList => _stageList;

    [SerializeField] SaveData _saveData;
    public SaveData SaveDataInfo
    {
        get => _saveData;
        set => _saveData = value;
    }

    public void SetProcessValue(List<float> processValues)
    {
        _saveData._processValues = processValues;
        SaveData();
    }

    public void SetSkinValue(List<SkinValue> skinValues)
    {
        _saveData._skinValues = skinValues;
        SaveData();
    }

    private void Awake()
    {
        LoadData();
    }

    void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);

            if (jsonData == null)
            {
                InitData();
            }
            else
            {
                _saveData = JsonUtility.FromJson<SaveData>(jsonData);
            }
        }
        else
        {
            InitData();
        }

        _stageList.Init(_saveData._processValues);
        _skinList.Init(_saveData._skinValues);
    }

    public void InitData()
    {
        _saveData._processValues.Clear();

        for (int i = 0; i < _stageList._stageList.Count; i++)
        {
            _saveData._processValues.Add(0f);
        }

        _saveData._skinValues.Clear();
        for (int i = 0; i < _skinList._skinInfoList.Count; i++)
        {
            _saveData._skinValues.Add(new SkinValue
            {
                _currentTextures = _skinList._skinInfoList[i]._modelList[0]._modelTex,
                _lockList = new List<bool> { true },
            });
        }

        SaveData();
    }

    [ContextMenu("Save")]
    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(_saveData, true);
        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");
        File.WriteAllText(path, jsonData);
    }
}

[System.Serializable]
public class SaveData
{
    public List<SkinValue> _skinValues;
    public List<float> _processValues;
}

[System.Serializable]
public class SkinValue
{
    public Texture _currentTextures;
    public List<bool> _lockList;
}
