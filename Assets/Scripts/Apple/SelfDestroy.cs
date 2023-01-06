using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private void Start()
    {
        DestroyGameObject();    
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject, 5f);
    }
}
