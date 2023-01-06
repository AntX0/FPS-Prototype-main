using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{

    [SerializeField] private float _chaseRange;
    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private bool _isPlayerTarget = true;
    [SerializeField] private Transform _target;

    private EnemyHealth _health;
    private NavMeshAgent _navMeshAgent;
    private float _distanceToTarget = Mathf.Infinity;
    bool isProvoked;
    
    public bool IsPlayerTarget => _isPlayerTarget;


    private void Start()
    {
        _target = DefineTargetPosition();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _health = GetComponent<EnemyHealth>();
        GetComponent<EnemyHealth>().OnTakenDamage += (sender, args) => isProvoked = true;
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }

    private Transform DefineTargetPosition()
    {
        if (_isPlayerTarget)
            return FindObjectOfType<PlayerHealth>().transform;
        else
            return FindObjectOfType<AppleHitPoints>().transform;
    }

    private void Update()
    {
        if (_health.IsDead)
        {
            _navMeshAgent.enabled = false;
            return;
        }
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);
        if (isProvoked)
        {
            if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
                RotateToTarget();
            EngageTarget();
        }
        else if (_distanceToTarget <= _chaseRange)
        {
            isProvoked = true;
        }
    }


    private void EngageTarget()
    {
        if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        _navMeshAgent.SetDestination(_target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void RotateToTarget()
    {
        Vector3 directionToTarget = (_target.position - transform.position).normalized;
        Quaternion lookAtRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, Time.deltaTime * _turnSpeed);
    }
}
