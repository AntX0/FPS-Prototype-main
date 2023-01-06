using Cinemachine;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private AppleHitPoints _target;
    [SerializeField] private PlayerHealth _targetPlayer;
    [SerializeField] private float _damage = 40f;
    private bool _isPlayer;
    private CameraShake _camera;
    


    void Start()
    {
        _isPlayer = GetComponent<EnemyAI>().IsPlayerTarget;
        _targetPlayer = FindObjectOfType<PlayerHealth>();
        _target = FindObjectOfType<AppleHitPoints>();
        _camera = FindObjectOfType<CameraShake>();
    }

    public void AttackHitEvent()
    {
        if (_isPlayer)
        {
            if (_targetPlayer.isActiveAndEnabled == false) { Destroy(gameObject, 0.1f); }
            _targetPlayer.DecreaseHitPoints(_damage);
            _camera.PlayCameraShakeAnimation();
        }
        else
        {
            if (_target.isActiveAndEnabled == false) { Destroy(gameObject, 0.1f); }
            _target.DecreaseAppleHitPoints(_damage);
        }
    }
}
