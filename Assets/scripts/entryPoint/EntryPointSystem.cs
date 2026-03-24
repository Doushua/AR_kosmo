using System;
using System.Collections.Generic;
using localdata;
using UnityEngine;

public class EntryPointSystem : MonoBehaviour
{
    public static EntryPointSystem instance { get; private set; }
    
    [Header("системы")]
    [SerializeField] private List<GameObject> inits;

    /// <summary>
    /// Реализация паттерна проектирования - Singlton
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    private System.Collections.IEnumerator Start()
    {
        foreach (var init in inits)
        {
            if(init.TryGetComponent(out IInit component))
                component.Init();
        }

        yield return null;
    }
}
