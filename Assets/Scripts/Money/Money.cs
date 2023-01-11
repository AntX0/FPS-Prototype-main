using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private int _currentCoinAmmount = 0;
    [SerializeField] private TextMeshProUGUI _currentCoinsText;

    public int CurrentCoinAmmount => _currentCoinAmmount;


    private void Update()
    {
        DisplayCoins();
    }

    public void IncreaseCoinAmmount()
    {
        if (_currentCoinAmmount < 0) { _currentCoinAmmount = 0; return; }
        int _coinPickup = FindObjectOfType<CoinPickup>().CoinValue;
        _currentCoinAmmount += _coinPickup;
    }

    public void DecreaseCoinAmmount(int ammountToDecrease)
    {
        if (_currentCoinAmmount <= 0) { _currentCoinAmmount = 0; return; }
        _currentCoinAmmount -= ammountToDecrease;
    }

    private void DisplayCoins()
    {
        _currentCoinsText.text = $"Coins - {_currentCoinAmmount}";
    }
}
