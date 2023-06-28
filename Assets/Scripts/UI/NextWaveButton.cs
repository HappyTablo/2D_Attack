using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _spawner.AllEnemiesSpawned += OnAllEnemiesSpawned;
        _button.onClick.AddListener(OnNextWaveClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemiesSpawned -= OnAllEnemiesSpawned;
        _button.onClick.RemoveListener(OnNextWaveClick);
    }

    private void OnAllEnemiesSpawned()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnNextWaveClick()
    {
        _spawner.NextWave();
        _button.gameObject.SetActive(false);
    }

}
