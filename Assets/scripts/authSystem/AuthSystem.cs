using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using localdata;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AuthSystem : MonoBehaviour, IInit
{
    public UnityEvent OnAuth;
    public UnityEvent OnRegister;
    
    [SerializeField] private string login;
    [SerializeField] private string password;
    [SerializeField] private string confirmPassword;
    [SerializeField] private string name;
    
    [SerializeField] private Button authButton;
    [SerializeField] private Button regButton;
    
    enum AuthType
    {
        None, Auth, Register
    }
    
    /// <summary>
    /// Метод инициализации
    /// </summary>
    public void Init()
    {
        Debug.Log("Система авторизации проинициализирована");
    }

    /// <summary>
    /// метод регистрация
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public void Registration()
    {
        var users = LocalDataSystem.instance.LocalData.users;
        
        if (users.FirstOrDefault(x => x.login == login && x.password == password) == null)
        {
            var authdata = new AuthData();
            authdata.login = login;
            authdata.password = password;
            authdata.name = name;
            
            LocalDataSystem.instance.LocalData.users.Add(authdata);
            LocalDataSystem.instance.Save();
            
            OnRegister.Invoke();
        }
    }
    /// <summary>
    /// Метод авторизации
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [CanBeNull]
    public void Auth()
    {
        var users = LocalDataSystem.instance.LocalData.users;
        
        var user = users.FirstOrDefault(x => x.login == login && x.password == password);
        if (users.Any() && user != null)
            OnAuth?.Invoke();
    }

    private bool AuthConfirm()
    {
        bool result = !string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password);
        
        return result;
    }

    private bool RegistrationConfirm()
    {
        bool result = !string.IsNullOrWhiteSpace(login)
                      && !string.IsNullOrWhiteSpace(name)
                      && !string.IsNullOrWhiteSpace(password) 
                      && !string.IsNullOrWhiteSpace(confirmPassword);
        
        result &= string.Equals(password, confirmPassword);
        
        return result;
    }
#region auth
    public void ChangeLoginFieldAuth(string value)
    {
        login = value;
        authButton.interactable = AuthConfirm();
    }
    

    public void ChangePasswordFieldAuth(string value)
    {
        password = value;
        authButton.interactable = AuthConfirm();
    }
    #endregion

#region register
    public void ChangeNameField(string value)
    {
        name = value;
        regButton.interactable = RegistrationConfirm();
    }
    
    public void ChangeLoginFieldReg(string value)
    {
        login = value;
        regButton.interactable = RegistrationConfirm();
    }
    
    public void ChangePasswordFieldReg(string value)
    {
        password = value;
        regButton.interactable = RegistrationConfirm();
    }
    
    public void ChangeConfirmPasswordFieldReg(string value)
    {
        confirmPassword = value;
        regButton.interactable = RegistrationConfirm();
    }
    
#endregion
}
