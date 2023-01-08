using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _turretDamage = 10f;

    private TurretTargetLocator _turretTarget;
    private float _time;

    private void Start()
    {
        _turretTarget = GetComponent<TurretTargetLocator>();
    }

    public void AttackTarget()
    {
        _time += Time.deltaTime;
        float nextTimeToShoot = 1 / _fireRate;

        var direction = _turretTarget.Target.position - transform.position;
        if (_time >= nextTimeToShoot)
        {
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _turretTarget.TurretAttackRange))
            {
                if (hit.transform == null) { return; }
                Debug.Log(hit.collider.name);
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
        }
        else
        {
            return;
        }
    }
}
