using System;
using System.IO;
using localdata;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class LocalDataSystem : MonoBehaviour, IInit
{
    public static LocalDataSystem instance { get; set; }
    private string dataPath { get; set; }
    [SerializeField] private string dataFile;
    [field:SerializeField] public LocalData LocalData {get; set; }

    public void Init()
    {
#region singlton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
#endregion

#region initialization
        dataPath = Path.Combine(Application.persistentDataPath, dataFile);
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
#endregion
    }

    /// <summary>
    /// метод сохранения данных
    /// </summary>
    public void Save()
    {
        File.WriteAllText(dataPath, JsonUtility.ToJson(LocalData));
    }
}
