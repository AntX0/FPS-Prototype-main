using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    private TurretTargetLocator _turretTarget;

    private void Start()
    {
          _turretTarget = GetComponent<TurretTargetLocator>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.forward);
    }

    public void AttackTarget()
    {

        if (Physics.Raycast(transform.position, _turretTarget.Target.position, out RaycastHit hit, _turretTarget.TurretAttackRange))
            Debug.Log(gameObject.name);
            if (hit.transform.GetComponent<EnemyHealth>() == true)
            {
                Debug.Log("Hit");
            }

    }
}
