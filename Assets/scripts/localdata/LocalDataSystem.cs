using System;
using System.IO;
using localdata;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class LocalDataSystem : IInit
{
    private readonly string dataPath;
    private readonly string fileName; 
    [field:SerializeField] public LocalData LocalData {get; set; }

    public LocalDataSystem(string fileName)
    {
        this.fileName = fileName;
        
        dataPath = Path.Combine(Application.persistentDataPath, fileName);
    }

    public void Init()
    {
        if (!File.Exists(dataPath))
        {
            File.CreateText(dataPath).Close();
        }
        else
        {
            string json = File.ReadAllText(dataPath);
            
            if(!string.IsNullOrEmpty(json))
                LocalData = JsonUtility.FromJson<LocalData>(json);
        }
    }

    public void Save()
    {
        File.WriteAllText(dataPath, JsonUtility.ToJson(LocalData));
    }
}
