using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private float _ammountToIncrease = 10f;
    [SerializeField] private int _upgradeCost;

    public int UpgradeCost => _upgradeCost;

    private Weapon _weapon;
    private Money _money;

    private void Start()
    {
        _money = FindObjectOfType<Money>();
        _weapon = _weaponPrefab.GetComponent<Weapon>();
    }

    public float IncreaseWeaponDamage()
    {
        _money.DecreaseCoinAmmount(_upgradeCost);
        float currentDamage = _weapon.GetCurrentDamage();
        return currentDamage += _ammountToIncrease;
    }
}
