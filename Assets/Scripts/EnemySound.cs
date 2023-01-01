using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _footstepsFX;

    public void PlayFootstep()
    {
        int randomValue = Random.Range(0, _footstepsFX.Length);
        _audioSource.PlayOneShot(_footstepsFX[randomValue]);
    }
}
