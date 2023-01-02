using UnityEngine;

public class AppleHitPoints : MonoBehaviour
{
    [Range(0, 999)] [SerializeField] private float _appleHitPoints = 100f;
    [SerializeField] private float _currentHealth;

    void Start()
    {
        _currentHealth = _appleHitPoints;
    }

    public void DecreaseAppleHitPoints(float amountToDecrease)
    {
        _currentHealth -= amountToDecrease;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            gameObject.SetActive(false);
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
