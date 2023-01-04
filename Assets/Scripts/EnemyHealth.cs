using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _hitPoints;
    [SerializeField] private float _currentHitPoints;
    [SerializeField] private EnemySound _deathSoundFX;
    [SerializeField] private bool _isDead = false;

    private NavMeshAgent _navMeshAgent;
    private LootDrop _lootDrop;

    public bool IsDead => _isDead;

    private void Start()
    {
        _lootDrop = GetComponent<LootDrop>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentHitPoints = _hitPoints;
        _deathSoundFX = GetComponent<EnemySound>();
    }

    public void TakeDamage(float damage)
    {
        OnTakenDamage?.Invoke(this, null);
        _currentHitPoints -= damage;

        if (_currentHitPoints <= 0)
        {
            _currentHitPoints = 0;
            Die();
        }
    }

    private void Die()
    {
        if (_isDead) { return; }

        _isDead = true;
        _lootDrop.DropLoot();
        _deathSoundFX.PlayDeathSound();
        GetComponent<Animator>().SetTrigger("dead");
        Invoke(nameof(ProcessResurection), 1f);
    }

    private void ProcessResurection()
    {
        gameObject.SetActive(false);
        _isDead = false;
        _navMeshAgent.enabled = true;
        transform.position = GetComponentInParent<Transform>().transform.position;
        _hitPoints += 25;
        _currentHitPoints += _hitPoints;
    }

    public event EventHandler OnTakenDamage;
}
