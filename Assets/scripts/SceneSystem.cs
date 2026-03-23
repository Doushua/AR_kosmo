using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Система управлением сценами
/// </summary>
public class SceneSystem
{
    /// <summary>
    /// Метод смены сцены
    /// </summary>
    /// <param name="sceneName"></param>
    public IEnumerator ChangeScene(string sceneName)
    {
        var operation = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitUntil(() => operation.isDone);
    }
}
