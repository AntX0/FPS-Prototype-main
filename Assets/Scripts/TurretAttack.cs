using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _turretDamage = 10f;

    private TurretTargetLocator _turretTarget;
    private float _nextTimeToShoot;

    private void Start()
    {
        _turretTarget = GetComponent<TurretTargetLocator>();
    }

    public void AttackTarget()
    {
        var direction = _turretTarget.Target.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _turretTarget.TurretAttackRange))
        {
            if (hit.transform == null) { return; }
            Debug.Log(hit.collider.name);
            _nextTimeToShoot = Time.time + 1f / _fireRate;
            ApplyDamage(hit);
        }
    }

    private void ApplyDamage(RaycastHit hit)
    {
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target)
        {
            target.TakeDamage(_turretDamage);
        }
        else
        {
            return;
        }
    }
}
