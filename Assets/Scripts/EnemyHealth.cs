using System;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _hitPoints;
    [SerializeField] private EnemySound _deathSoundFX;

    private bool _isDead = false;

    public bool IsDead => _isDead;

    private void Start()
    {
        _deathSoundFX = GetComponent<EnemySound>();
    }

    public void TakeDamage(float damage)
    {
        OnTakenDamage?.Invoke(this, null);
        _hitPoints -= damage;

        if (_hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isDead) { return; }
        _isDead= true;
        _deathSoundFX.PlayDeathSound();
        GetComponent<Animator>().SetTrigger("dead");
        Destroy(gameObject, 3f);
    }

    public event EventHandler OnTakenDamage;
}
