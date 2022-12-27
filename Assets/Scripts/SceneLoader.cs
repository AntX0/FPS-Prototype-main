using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale= 1.0f;
        Cursor.visible= false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
