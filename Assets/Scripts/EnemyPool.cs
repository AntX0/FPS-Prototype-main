using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField][Range(0, 50)] private int _poolSize;
    [SerializeField][Range(0.1f, 30f)] private float _spawnRate;

    

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[_poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            int randomValue = Random.Range(0, _enemyPrefab.Length);
            pool[i] = Instantiate(_enemyPrefab[randomValue], transform);
            pool[i].SetActive(false);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

}
