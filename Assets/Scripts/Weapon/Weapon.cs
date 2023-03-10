using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] private float _range;
    [SerializeField] InputAction shoot;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject[] _hitEffect;
    [SerializeField] private float _fireRate;
    [SerializeField] private Ammo _ammoSlot;
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _gunShot;

    private float _currentDamage;
    private float _nextTimeToFire = 0;
    private Animator _animator;
    private Money _money;

    private void OnEnable()
    {
        shoot.Enable();
    }

    private void OnDisable()
    {
        shoot.Disable();
    }

    private void Start()
    {
        _money = FindObjectOfType<Money>();
        _currentDamage = _damage;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        DisplayAmmo();
        if (shoot.IsPressed() && _nextTimeToFire <= Time.time)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();
        }
        else if (shoot.IsPressed() == false)
        {
            _animator.SetBool("Shoot", false);
        }
    }

    public float GetCurrentDamage()
    {
        return _currentDamage;
    }

    private void DisplayAmmo()
    {
        int currentAmmo = _ammoSlot.GetCurrentAmmo(_ammoType);
        _ammoText.text = $"{_ammoType} {currentAmmo}";
    }

    private void Shoot()
    {
        if (_ammoSlot.GetCurrentAmmo(_ammoType) == 0) { _animator.SetBool("Shoot", false); return; }
        _ammoSlot.ReduceCurrentAmmo(_ammoType);
        _animator.SetBool("Shoot", true);
        ProcessRayCast();
        PlayMuzzleFlash();
        PlaySoundEffect();
    }

    private void PlaySoundEffect()
    {
        _audioSource.PlayOneShot(_gunShot);
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
            IdentifyTargetType(hit);
        }
        else
        {
            return;
        }
    }

    private void IdentifyTargetType(RaycastHit hit)
    {
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        UpgradeButton button = hit.transform.GetComponent<UpgradeButton>();

        if (target)
        {
            target.TakeDamage(_currentDamage);
        }
        else if (button && gameObject.CompareTag("Rifle") && _money.CurrentCoinAmmount >= button.UpgradeCost)
        {
            _currentDamage = button.IncreaseWeaponDamage();
            Debug.Log(_currentDamage);
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        if (hit.transform == null) { return; }
        if (hit.transform.GetComponent<EnemyHealth>() == true)
        {
            GameObject impact = Instantiate(_hitEffect[1], hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 0.1f);
        }
        else
        {
            GameObject impact2 = Instantiate(_hitEffect[0], hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact2, 0.1f);
        }
    }
}
