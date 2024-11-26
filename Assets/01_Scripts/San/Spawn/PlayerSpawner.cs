using Redcode.Pools;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private DeckSO _spawns;

    [SerializeField] private PoolManager _poolManager;

    [SerializeField] private Transform _spawnPoint;

    public void SpawnEntity(int agentIndex)
    {
        string agentName = _spawns.agentDeckList[agentIndex].agentName;

        Agent _spawnAgent = _poolManager.GetFromPool<Agent>(agentName);

        _spawnAgent.transform.position = _spawnPoint.position;
    }
}
