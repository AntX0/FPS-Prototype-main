using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _hitPoints;
    [SerializeField] private float _currentHitPoints;
    [SerializeField] private EnemySound _deathSoundFX;
    [SerializeField] private bool _isDead = false;

    private NavMeshAgent _navMeshAgent;

    public bool IsDead => _isDead;

    private void Start()
    {
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
        _deathSoundFX.PlayDeathSound();
        GetComponent<Animator>().SetTrigger("dead");
        Invoke(nameof(ProcessResurection), 3f);
    }

    private void ProcessResurection()
    {
        gameObject.SetActive(false);
        _isDead = false;
        _navMeshAgent.enabled = true;
        transform.position = FindObjectOfType<EnemyPool>().transform.position;
        _currentHitPoints += _hitPoints;
    }

    public event EventHandler OnTakenDamage;
}
