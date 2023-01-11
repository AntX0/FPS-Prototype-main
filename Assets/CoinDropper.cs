using UnityEngine;
using UnityEngine.InputSystem;

public class CoinDropper : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private InputAction _dropCoin;
    private Money _money;
    private int _coinValue;

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
    }

    private void Update()
    {
        DropCoin();
    }

    private void DropCoin()
    {
        if (_dropCoin.WasPressedThisFrame() && _money.CurrentCoinAmmount > 0)
        {
            _money.DecreaseCoinAmmount(_coinValue);
        }
    }
}
