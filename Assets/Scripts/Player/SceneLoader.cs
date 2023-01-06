using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale= 1.0f;
        Cursor.visible= false;
        FindObjectOfType<CameraShake>().GetComponent<CinemachineVirtualCamera>().m_Lens.Dutch = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}