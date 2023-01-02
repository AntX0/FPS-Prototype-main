using Cinemachine;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] AppleHitPoints target;
    [SerializeField] private float _damage = 40f;
    private CameraShake _camera;

    void Start()
    {
        target = FindObjectOfType<AppleHitPoints>();
        _camera = FindObjectOfType<CameraShake>();
    }

    public void AttackHitEvent()
    {
        if (target.isActiveAndEnabled == false) { Destroy(gameObject, 0.1f); }
        target.DecreaseAppleHitPoints(_damage);
        /*_camera.PlayCameraShakeAnimation();*/
    }
}
