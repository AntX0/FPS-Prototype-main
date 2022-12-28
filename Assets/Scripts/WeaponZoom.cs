using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _fpsCamera;
    [SerializeField] private float _zoomedOutFieldOfView = 90f;
    [SerializeField] private float _zoomedInFieldOfView = 20f;
    [SerializeField] InputAction aim;

    private void OnEnable()
    {
        aim.Enable();
    }

    private void OnDisable()
    {
        aim.Disable();
    }

    private void Update()
    {
        if (aim.IsPressed())
        {
            _fpsCamera.m_Lens.FieldOfView = _zoomedInFieldOfView;
        }
        else
        {
            _fpsCamera.m_Lens.FieldOfView = _zoomedOutFieldOfView;
        }
    }
}
