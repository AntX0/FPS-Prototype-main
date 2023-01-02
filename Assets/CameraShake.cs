using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void PlayCameraShakeAnimation()
    {
        GetComponent<Animator>().SetTrigger("take damage");
    }
}
