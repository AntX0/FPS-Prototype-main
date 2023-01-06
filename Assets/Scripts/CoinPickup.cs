using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int _coinAmount = 10;
    [SerializeField] private AudioClip _coinPickupSound;
    private PlayerHealth _player;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _player = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_player)
        {
            _audioSource.PlayOneShot(_coinPickupSound);
            FindObjectOfType<Money>().IncreaseCoinAmmount();
            Destroy(gameObject, 0.3f);
        }
    }
}
