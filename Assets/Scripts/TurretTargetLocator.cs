using System;
using UnityEngine;

public class TurretTargetLocator : MonoBehaviour
{
    [SerializeField] private float _turretRotationSpeed;
    [SerializeField] private float _turretAttackRange;
   

    private Transform _target;
    private Quaternion _turretStartRotation;
    private TurretAttack _turretAttack;

    public float TurretAttackRange => _turretAttackRange; 
    public Transform Target => _target;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _turretAttackRange);
    }

    private void Start()
    {
        _turretStartRotation = Quaternion.LookRotation(new Vector3 (0f, 0f, 0f));
        _turretAttack = GetComponent<TurretAttack>();
    }

    private void Update()
    {
        FindClosestTarget();
        if (_target == null) { ResetRotation(); return; }
        RotateAtTarget();
        _turretAttack.AttackTarget();
    }

    private void FindClosestTarget()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        Transform closestEnemy = null;
        float maxDistacne = _turretAttackRange;

        foreach (EnemyHealth enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistacne)
            {
                closestEnemy = enemy.transform;
                maxDistacne = targetDistance;
            }
        }

        _target = closestEnemy;
    }

    private void RotateAtTarget()
    {
        float targetDistance = Vector3.Distance(transform.position, _target.transform.position);
        if (targetDistance < _turretAttackRange)
        {
            Vector3 direction = _target.position - transform.position;
            Quaternion lookAtRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, Time.deltaTime * _turretRotationSpeed);
        }
    }

    private void ResetRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, _turretStartRotation, Time.deltaTime * _turretRotationSpeed);
    }
}
