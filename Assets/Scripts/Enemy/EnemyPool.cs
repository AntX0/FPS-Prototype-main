using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField][Range(0, 50)] private int _poolSize;
    [SerializeField][Range(0.1f, 100f)] private float _spawnRate;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(DifficultyIncrease());
    }

    private IEnumerator DifficultyIncrease()
    {
        while (true && _spawnRate >= 10)
        {
            _spawnRate -= 1;
            yield return new WaitForSeconds(30);
        }
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
