using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPoint;

    public event UnityAction AllEnemiesSpawned;
    
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _lastSpawnedTime;
    private int _spawnedEnemies;

    private void Awake()
    {
        _currentWave = _waves[_currentWaveNumber];
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _lastSpawnedTime += Time.deltaTime;


        if (_lastSpawnedTime >= _currentWave.Delay)
        {
            CreateEnemy();
            _spawnedEnemies++;
            _lastSpawnedTime = 0;
        }

        if (_currentWave.Amount <= _spawnedEnemies)
        {
            if (_waves.Count > _currentWaveNumber + 1)
                AllEnemiesSpawned?.Invoke();

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        _currentWave = _waves[++_currentWaveNumber];
        _spawnedEnemies = 0;
    }

    private void CreateEnemy()
    {
        for (int i = 0; i < _currentWave.Prefabs.Length; i++)
        {
            Enemy enemy = Instantiate(_currentWave.Prefabs[i], _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
            enemy.Init(_player);
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] Prefabs;
    public int Amount;
    public float Delay;
}
