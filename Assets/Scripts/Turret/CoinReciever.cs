using UnityEngine;

public class CoinReciever : MonoBehaviour
{
    private int _recievedCoinsAmount;
    private int _coinValue;

    public int RecievedCoinsAmount => _recievedCoinsAmount;

    private void Start()
    {
        _coinValue = FindObjectOfType<CoinPickup>().CoinValue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SelfDestroy>())
        {
            _recievedCoinsAmount += _coinValue;
            Debug.Log(_recievedCoinsAmount);
            Destroy(collision.gameObject);
        }
    }
}
