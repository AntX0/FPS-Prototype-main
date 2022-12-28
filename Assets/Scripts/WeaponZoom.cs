using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _fpsCamera;
    [SerializeField] private float _zoomedOutFieldOfView = 90f;
    [SerializeField] private float _zoomedInFieldOfView = 20f;
    [SerializeField] private InputAction _aim;
    [SerializeField] private float _mouseSensitivity = 1f;
    [SerializeField] private float _zoomedInMouseSensitivity = 0.5f;
    private FirstPersonController _rotationSpeed;

    private void OnEnable()
    {
        _aim.Enable();
    }

    private void OnDisable()
    {
        _aim.Disable();
    }

    private void Start()
    {
        _rotationSpeed = GetComponentInParent<FirstPersonController>();
    }

    private void Update()
    {
        if (_aim.IsPressed())
        {
            _fpsCamera.m_Lens.FieldOfView = _zoomedInFieldOfView;
            _rotationSpeed.RotationSpeed = _zoomedInMouseSensitivity;
        }
        else
        {
            _fpsCamera.m_Lens.FieldOfView = _zoomedOutFieldOfView;
            _rotationSpeed.RotationSpeed = _mouseSensitivity;
        }
    }
}
