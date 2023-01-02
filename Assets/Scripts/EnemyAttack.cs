using Cinemachine;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;
    [SerializeField] private float _damage = 40f;
    private CameraShake _camera;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        _camera = FindObjectOfType<CameraShake>();
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.DecreaseHitPoints(_damage);
        _camera.PlayCameraShakeAnimation();
    }
}
