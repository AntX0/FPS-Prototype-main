using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _playerHitPoints = 120f;
    [SerializeField] private DisplayDamage _impact;

    public void DecreaseHitPoints(float amountToDecrease)
    {
        _playerHitPoints -= amountToDecrease;
        _impact.ShowDamageImpact();
        if ( _playerHitPoints <= 0 )
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
