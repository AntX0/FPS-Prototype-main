using System.Collections;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] private Canvas _impactCanvas;
    [SerializeField] private float _impactTime = 1.0f;

    private void Start()
    {
        _impactCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(DisplayDamageImpact());
    }

    private IEnumerator DisplayDamageImpact()
    {
        _impactCanvas.enabled = true;
        yield return new WaitForSeconds(_impactTime);
        _impactCanvas.enabled = false;
    }
}
