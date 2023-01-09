using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class TurretAttack : MonoBehaviour
{
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _turretDamage = 10f;
    [SerializeField] private GameObject _hitEffect;

    
    private TurretTargetLocator _turretTarget;
    private float _time;
    private TurretAudioHandler _turretAudio;

    private void Start()
    {
        _turretTarget = GetComponent<TurretTargetLocator>();
        _turretAudio = GetComponent<TurretAudioHandler>();
    }

    public void AttackTarget()
    {
        OnAttack?.Invoke(this, null);
        _time += Time.deltaTime;
        float nextTimeToShoot = 1 / _fireRate;
        var direction = transform.forward;

        ProcessAttack(nextTimeToShoot, direction);
    }

    private void ProcessAttack(float nextTimeToShoot, Vector3 direction)
    {
        if (_time >= nextTimeToShoot)
        {
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _turretTarget.TurretAttackRange))
            {
                if (hit.transform == null) { return; }

                _turretAudio.PlayAttackSound();
                ApplyDamage(hit);
            }

            _time = 0;
        }
    }

    private void ApplyDamage(RaycastHit hit)
    {
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target)
        {
            target.TakeDamage(_turretDamage);
            Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
        else
        {
            return;
        }
    }

    public EventHandler OnAttack;
}
