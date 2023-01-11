using UnityEngine;
using UnityEngine.InputSystem;

public class CoinDropper : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private InputAction _dropCoin;
    private Money _money;
    private int _coinValue;
    private Camera _mainCamera;

    private void OnEnable()
    {
        _dropCoin.Enable();
    }

    private void OnDisable()
    {
        _dropCoin.Disable();
    }

    private void Start()
    {
        _money = GetComponent<Money>();
        _coinValue = FindObjectOfType<CoinPickup>().CoinValue;
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        DropCoin();
    }

    private void DropCoin()
    {
        Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y + 1.4f, transform.position.z);
        if (_dropCoin.WasPressedThisFrame() && _money.CurrentCoinAmmount >= _coinValue)
        {
            _money.DecreaseCoinAmmount(_coinValue);
            GameObject instacne = Instantiate(_coinPrefab, dropPosition, Quaternion.identity);
            instacne.GetComponent<Rigidbody>().AddForce(100 * _mainCamera.transform.forward, ForceMode.Impulse);
        }
    }
}
