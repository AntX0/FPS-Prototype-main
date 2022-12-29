using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int _ammoAmount = 10;
    [SerializeField] private AmmoType _ammoType;
    private PlayerHealth _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_player)
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_ammoType, _ammoAmount);
            Destroy(gameObject);
        }
    }
}
