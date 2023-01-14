using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    [SerializeField] private int _turretPrice = 50;
    [SerializeField] private GameObject _turretPrefab;

    private CoinReciever _coinReciever;
    private TurretBuilderFX _turretFX;
    private bool _isPlaced = false;

    private void Awake()
    {
        _coinReciever = GetComponent<CoinReciever>();
        _turretFX = GetComponent<TurretBuilderFX>();
    }

    private void Update()
    {
        if (_coinReciever.RecievedCoinsAmount >= _turretPrice && _isPlaced == false)
        {
            _turretFX.InstantiateBuildVFX();
            InstantiateTurret();
            Destroy(gameObject, 1f);
        }
    }

    private void InstantiateTurret()
    {
        Vector3 buildPositon = new(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        Instantiate(_turretPrefab, buildPositon, Quaternion.identity);
        _turretFX.PlayBuildSFX();
        _isPlaced = true;
    }
}
