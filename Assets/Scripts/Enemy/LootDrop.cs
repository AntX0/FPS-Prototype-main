using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    [SerializeField] private List<GameObject> _possibleLoot = new List<GameObject>();

    private Transform _enemy;

    private void Start()
    {
        _enemy = GetComponent<Transform>().transform;
    }

    public void DropLoot()
    {
        Instantiate(_possibleLoot[Random.Range(0, _possibleLoot.Capacity)], _enemy.position, Quaternion.identity);
    }
}
