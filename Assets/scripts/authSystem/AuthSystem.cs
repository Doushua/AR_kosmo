using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using localdata;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AuthSystem : MonoBehaviour, IInit
{
    public static AuthSystem instance { get; set; }
    public UnityEvent OnAuth;
    public UnityEvent OnRegister;
    
    /// <summary>
    /// Метод инициализации
    /// </summary>
    public void Init()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(gameObject);
        
        Debug.Log("Система авторизации проинициализирована");
    }

    /// <summary>
    /// метод регистрация
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool Registration(RegisterData data)
    {
        var users = LocalDataSystem.instance.LocalData.users;
        
        if (users.FirstOrDefault(x => x.login == data.login) == null)
        {
            var authdata = new AuthData();
            authdata.login = data.login;
            authdata.password = data.password;
            authdata.name = data.name;
            
            LocalDataSystem.instance.LocalData.users.Add(authdata);
            LocalDataSystem.instance.Save();
            
            OnRegister.Invoke();
            return true;
        }

        return false;
    }
    /// <summary>
    /// Метод авторизации
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public bool Auth(AuthData data)
    {
        var users = LocalDataSystem.instance.LocalData.users;
        
        var user = users.FirstOrDefault(x => x.login == data.login && x.password == data.password);
        if (users.Any() && user != null)
        {
            OnAuth?.Invoke();
            return true;
        }
        else
            return false;
    }

    public bool AuthConfirm(AuthData data)
    {
        bool result = !string.IsNullOrWhiteSpace(data.login) && !string.IsNullOrWhiteSpace(data.password);
        
        return result;
    }

    public bool RegistrationConfirm(RegisterData data)
    {
        bool result = !string.IsNullOrWhiteSpace(data.login)
                      && !string.IsNullOrWhiteSpace(data.name)
                      && !string.IsNullOrWhiteSpace(data.password) 
                      && !string.IsNullOrWhiteSpace(data.confirmPassword);
        
        result &= string.Equals(data.password,data.confirmPassword);
        
        return result;
    }
}
