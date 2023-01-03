using UnityEngine;

public class AppleHitPoints : MonoBehaviour
{
    [Range(0, 999)] [SerializeField] private float _appleHitPoints = 100f;
    [SerializeField] private float _currentHealth;

    private DeathHandler _death;
    private AppleSounds _takeDamageFX;

    void Start()
    {
        _takeDamageFX = GetComponent<AppleSounds>();
        _death = FindObjectOfType<DeathHandler>();
        _currentHealth = _appleHitPoints;
    }

    public void DecreaseAppleHitPoints(float amountToDecrease)
    {
        _currentHealth -= amountToDecrease;
        _takeDamageFX.PlayTakeDamageFX();

        if (_currentHealth <= 0)
        {
            ProcessGameOver();
        }
    }

    private void ProcessGameOver()
    {
        _currentHealth = 0;
        _death.HandleDeath();
    }
}
