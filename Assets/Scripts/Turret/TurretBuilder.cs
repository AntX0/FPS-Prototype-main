using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    [SerializeField] private int _turretPrice = 50;
    [SerializeField] private GameObject _turretPrefab;
    private CoinReciever _coinReciever;


    private void Awake()
    {
        _coinReciever = GetComponent<CoinReciever>();
    }

    private void Update()
    {
        if (_coinReciever.RecievedCoinsAmount >= _turretPrice)
        {
            InstantiateTurret();
            Destroy(gameObject);
        }
    }

    private void InstantiateTurret()
    {
        Vector3 buildPositon = new(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        Instantiate(_turretPrefab, buildPositon, Quaternion.identity);
    }
}
