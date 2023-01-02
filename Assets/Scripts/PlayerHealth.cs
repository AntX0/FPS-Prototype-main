using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _playerHitPoints = 100f;
    [SerializeField] private DisplayDamage _impact;
    [SerializeField] private Image _playerHealthFront;
    [SerializeField] private Image _playerHealthBackground;
    [SerializeField] private float _chipSpeed;

    private float _lerpTimer;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _playerHitPoints;
    }

    private void Update()
    {
        UpdateCurrentHealth();
    }

    public void DecreaseHitPoints(float amountToDecrease)
    {
        _currentHealth -= amountToDecrease;
        _lerpTimer = 0f;
        _impact.ShowDamageImpact();
        if (_currentHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    private void UpdateCurrentHealth()
    {
        float healthFraction = _currentHealth / _playerHitPoints;
        float fillFront = _playerHealthFront.fillAmount;
        _lerpTimer = _chipSpeed / Time.deltaTime;
        _playerHealthFront.fillAmount = Mathf.Lerp(fillFront, healthFraction, _chipSpeed);
    }
}
