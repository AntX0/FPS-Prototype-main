using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _hitPoints;

    public void TakeDamage(float damage)
    {
        _hitPoints -= damage;

        if (_hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
