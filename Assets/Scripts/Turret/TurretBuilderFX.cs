using UnityEngine;

public class TurretBuilderFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _buildVFX;
    [SerializeField] private AudioSource _buildSFX;

    public void InstantiateBuildVFX()
    {
        Instantiate(_buildVFX, transform.position, Quaternion.identity);
    }

    public void PlayBuildSFX()
    {
        _buildSFX.Play();
    }
}
