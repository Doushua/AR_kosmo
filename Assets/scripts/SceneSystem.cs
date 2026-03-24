using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Система управлением сценами
/// </summary>
public class SceneSystem : MonoBehaviour
{
    /// <summary>
    /// Метод смены сцены
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeScene(string sceneName)
    {
        StartCoroutine(Changer(sceneName));
        
        IEnumerator Changer(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            yield return new WaitUntil(() => operation.isDone);
        }
    }
}
