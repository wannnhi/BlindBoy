using Redcode.Pools;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _bossNumber = 3;
    [SerializeField] private float _spawnDelay = 5f;

    [SerializeField] private PoolManager _poolManager;

    [SerializeField] private Transform _spawnPoint;

    Coroutine coroutine;

    private void Awake()
    {
        StartSpawn();
    }

    private void OnDisable()
    { 
        StopSpawn();
    }

    private void StartSpawn()
    {
        coroutine = StartCoroutine(SpawnEntity());
    }

    private void StopSpawn()
    {
        StopCoroutine(SpawnEntity());
    }

    private IEnumerator SpawnEntity()
    {
        for (int i = 0; i < _bossNumber; i++)
        {
            int enemyIndex = Random.Range(0, i);
            if(enemyIndex == _bossNumber -1)
            {
                enemyIndex = _bossNumber;
            }
            Agent _spawnAgent = _poolManager.GetFromPool<Agent>(enemyIndex);
            _spawnAgent.transform.position = _spawnPoint.position;

            float ranDelay = Random.Range(_spawnDelay -1, _spawnDelay + 1);
            yield return new WaitForSeconds(ranDelay);
        }
    }
}
