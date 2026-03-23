using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private SceneSystem sceneManager { get; } = new SceneSystem();
    
    /// <summary>
    /// Метод выхода из приложения
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
