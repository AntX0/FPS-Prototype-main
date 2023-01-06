using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _currentCoinAmmount = 0;

    public int CurrentCoinAmmount => _currentCoinAmmount;

    public void IncreaseCoinAmmount()
    {
        if (_currentCoinAmmount < 0) { return; }
        _currentCoinAmmount += 10;
    }

    public void DecreaseCoinAmmount(int ammountToDecrease)
    {
        _currentCoinAmmount -= ammountToDecrease;
    }
}
