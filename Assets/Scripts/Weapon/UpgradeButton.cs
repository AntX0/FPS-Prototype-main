using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private float _ammountToIncrease = 10f;

    private Weapon _weapon;

    private void Start()
    {
        _weapon = _weaponPrefab.GetComponent<Weapon>();
    }

    public float IncreaseWeaponDamage()
    {
        float currentDamage = _weapon.GetCurrentDamage();
        return currentDamage += _ammountToIncrease;
    }
}
