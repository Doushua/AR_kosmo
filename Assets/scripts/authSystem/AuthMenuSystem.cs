using localdata;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthMenuSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text authText;
    [SerializeField] private TMP_Text regText;
    
    [SerializeField] private AuthData authData;
    [SerializeField] private RegisterData regData;
    
    [SerializeField] private Button authButton;
    [SerializeField] private Button regButton;

    public void AuthBtn()
    {
        var result = AuthSystem.instance.Auth(authData);
        authText.text = result ? "Пользователь авторизовался успешно" : "Неправильный логин или пароль";
    }
    
    public void RegisterBtn()
    {
        var result = AuthSystem.instance.Registration(regData);
        regText.text = result ? "Пользователь успешно зарегистрирован" : "Такой пользователь уже существует";
    }
    
    #region auth
    public void ChangeLoginFieldAuth(string value)
    {
        authData.login = value;
        authButton.interactable = AuthSystem.instance.AuthConfirm(authData);
    }
    
    public void ChangePasswordFieldAuth(string value)
    {
        authData.password = value;
        authButton.interactable = AuthSystem.instance.AuthConfirm(authData);
    }
    #endregion

    #region register
    public void ChangeNameField(string value)
    {
        regData.name = value;
        regButton.interactable = AuthSystem.instance.RegistrationConfirm(regData);
    }
    
    public void ChangeLoginFieldReg(string value)
    {
        regData.login = value;
        regButton.interactable = AuthSystem.instance.RegistrationConfirm(regData);
    }
    
    public void ChangePasswordFieldReg(string value)
    {
        regData.password = value;
        regButton.interactable = AuthSystem.instance.RegistrationConfirm(regData);
    }
    
    public void ChangeConfirmPasswordFieldReg(string value)
    {
        regData.confirmPassword = value;
        regButton.interactable = AuthSystem.instance.RegistrationConfirm(regData);
    }
    
    #endregion
}
