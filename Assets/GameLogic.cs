using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    // Inspector
    [SerializeField]
    private GameObject _enemyObject;
    [SerializeField]
    private int _spawnRange;
    [SerializeField]
    private float _spawnRate;

    // Memory
    private float _timeToNextSpawn;

    private void Start()
    {
        _timeToNextSpawn = _spawnRate;
    }

    private void Update()
    {
        _timeToNextSpawn -= Time.deltaTime;
        if (_timeToNextSpawn < 0)
        {
            _timeToNextSpawn = _spawnRate;
            Vector2 spawnLocation = GetSpawnLocation();
            Instantiate(_enemyObject, spawnLocation, Quaternion.identity);
        }
    }

    private Vector2 GetSpawnLocation()
    {
        Vector2 spawnLocation = Vector2.zero;
        float angle = Random.Range(0, 360);

        spawnLocation.x = Mathf.Sin(angle * Mathf.Deg2Rad);
        spawnLocation.y = Mathf.Cos(angle * Mathf.Deg2Rad);
        spawnLocation *= _spawnRange;
        return spawnLocation;
    }

}
