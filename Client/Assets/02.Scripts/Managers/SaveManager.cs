using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{


    [SerializeField] SkinListSO _skinList;
    [SerializeField] StageListSO _stageList;

    [SerializeField] SaveData _saveData;


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
        _skinList.InitTex(_saveData._currentTextures);
    }

    public void InitData()
    {
        _saveData._processValues.Clear();

        for (int i = 0; i < _stageList._stageList.Count; i++)
        {
            _saveData._processValues.Add(0f);
        }

        _saveData._currentTextures.Clear();
        for (int i = 0; i < _skinList._skinInfoList.Count; i++)
        {
            _saveData._currentTextures.Add(_skinList._skinInfoList[i]._modelList[0]._modelTex);
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
    public List<float> _processValues;
    public List<Texture> _currentTextures;
}
