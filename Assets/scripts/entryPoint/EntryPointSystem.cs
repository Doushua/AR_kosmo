using System;
using System.Collections.Generic;
using localdata;
using UnityEngine;

public class EntryPointSystem : MonoBehaviour
{
    public static EntryPointSystem instance { get; private set; }

    [SerializeField] private string dataFile;
    [Header("системы")]
    [SerializeField] private AuthSystem authSystem;
    [SerializeField] public LocalDataSystem localDataSystem;

    public List<IInit> inits;

    /// <summary>
    /// Реализация паттерна проектирования - Singlton
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }

    private System.Collections.IEnumerator Start()
    {
        inits = new List<IInit>();
        localDataSystem = new LocalDataSystem(dataFile);
        
        if (localDataSystem is IInit item)
        {
            inits.Add(item);
        }

        foreach (var init in inits)
        {
            init.Init();
        }
        
        authSystem.users = localDataSystem.LocalData.users;
        
        yield return null;
    }
}
