using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale= 1.0f;
        Cursor.visible= false;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<CameraShake>().GetComponent<CinemachineVirtualCamera>().m_Lens.Dutch = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
