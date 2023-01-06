using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _footstepsFX;
    [SerializeField] private AudioClip _deathSound;

    public void PlayFootstep()
    {
        int randomValue = Random.Range(0, _footstepsFX.Length);
        _audioSource.PlayOneShot(_footstepsFX[randomValue]);
    }

    public void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_deathSound);
    }
}
