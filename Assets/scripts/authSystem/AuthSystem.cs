using System.Collections.Generic;
using System.Linq;
using localdata;
using UnityEngine;

public class AuthSystem : MonoBehaviour, IInit
{
    public List<AuthData> users;
    public void Init()
    {
        Debug.Log("Система авторизации проинициализирована");
    }

    public bool Registration(AuthData data)
    {
        if (users.FirstOrDefault(x => x.login == data.login && x.password == data.password) == null)
        {
            users.Add(data);
             
            EntryPointSystem.instance.localDataSystem.LocalData.users = users;
            EntryPointSystem.instance.localDataSystem.Save();

            return true;
        }
        else
            return false;
    }
    public bool Auth(AuthData data)
    {
        if (users.Any() && users.FirstOrDefault(x => x.login == data.login && x.password == data.password) != null)
        {
            users.Add(data);
            
            EntryPointSystem.instance.localDataSystem.LocalData.users = users;
            EntryPointSystem.instance.localDataSystem.Save();

            return true;
        }
        else
            return false;
    }
}
