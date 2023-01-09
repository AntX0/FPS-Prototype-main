using UnityEngine;

public class TurretAudioHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _turretAttackSFX;


    public void PlayAttackSound()
    {
        _audioSource.PlayOneShot(_turretAttackSFX); 
    }
}
