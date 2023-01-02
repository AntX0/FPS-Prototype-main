using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int _ammoAmount = 10;
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private AudioClip _ammoPickupSound;
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
            _audioSource.PlayOneShot(_ammoPickupSound);
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_ammoType, _ammoAmount);
            Destroy(gameObject, 0.3f);
        }
    }
}
