using UnityEngine;

public class TurretAudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _turretAttackSFX;
    [SerializeField] private AudioClip _turretProvokedSFX;


    public void PlayAttackSound()
    {
        _audioSource.PlayOneShot(_turretAttackSFX);
    }

    public void PlayProvokeSound()
    {
        _audioSource.Play();
    }
}
