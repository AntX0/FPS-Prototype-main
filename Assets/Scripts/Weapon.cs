using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] private float _range;
    [SerializeField] InputAction shoot;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _fireRate;
    private float _nextTimeToFire = 0;

    private void OnEnable()
    {
        shoot.Enable();
    }

    private void OnDisable()
    {
        shoot.Disable(); 
    }

    void Update()
    {
        if (shoot.IsPressed() && _nextTimeToFire <= Time.time)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        ProcessRayCast();
        PlayMuzzleFlash();
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, _range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target)
            {
                target.TakeDamage(_damage);
            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if (hit.transform == null) { return; }
        GameObject impact = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
