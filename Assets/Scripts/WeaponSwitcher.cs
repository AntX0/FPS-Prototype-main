using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private int _currentWeapon = 0;
    [SerializeField] private InputAction _keyToSwitchWeapon;
    [SerializeField] private Vector3 _defaultWeaponPosition = new Vector3(0.088f, 1.2f, 0.314f);

    private void OnEnable()
    {
        _keyToSwitchWeapon.Enable();
    }

    private void OnDisable()
    {
        _keyToSwitchWeapon.Disable();
    }

    void Start()
    {
        SetWeaponActive();
    }
   
    void Update()
    {
        int previousWeapon = _currentWeapon;

        ProcessKeyInput();

        if (previousWeapon != _currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessKeyInput()
    {
        if (_keyToSwitchWeapon.WasPressedThisFrame())
        {
            if (_currentWeapon == 0)
            {
                _currentWeapon = 1;
            }
            else 
            { 
                _currentWeapon = 0;
            }
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == _currentWeapon)
            {
                weapon.gameObject.GetComponent<Weapon>().enabled = true;
                weapon.gameObject.transform.localPosition = _defaultWeaponPosition;
            }
            else
            {
                weapon.gameObject.GetComponent<Weapon>().enabled = false;
                weapon.gameObject.transform.position = new Vector3(0, 0, 0);
            }
            weaponIndex++;
        }
    }

}
