using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale= 1.0f;
        Cursor.visible= false;
        /*GetComponent<FirstPersonController>().enabled = true;*/
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
