using System.Runtime.CompilerServices;
using UnityEngine;

public class AppleSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _takeDamageSound;

    public void PlayTakeDamageFX()
    {
        _audioSource.PlayOneShot(_takeDamageSound);
    }
}
