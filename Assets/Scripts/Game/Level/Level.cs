using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public delegate void LevelEndEvent();
    public event LevelEndEvent OnLevelEnd;
    
    public List<EnemyWaveConfig> EnemyWaves { get; set; }

    private bool _isPlayed;
    private int _currentAliveEnemyCount;
    private int _currentEnemyWaveIndex;
    
    public void StartLevel()
    {
        _isPlayed = true;
        _currentEnemyWaveIndex = -1;
        GenerateNextWave();
    }

    private void GenerateNextWave()
    {
        _currentEnemyWaveIndex++;
        var enemyWaveConfig = EnemyWaves[_currentEnemyWaveIndex];
        var enemies = EnemyWaveGenerator.GenerateWaveEnemies(enemyWaveConfig);
        _currentAliveEnemyCount = enemies.Count;
        foreach (var enemyGameObject in enemies)
        {
            enemyGameObject.GetComponent<Liveble>().OnDieEvent += OnEnemyDie;
        }
    }

    private void OnEnemyDie(Liveble enemyLiveble)
    {
        enemyLiveble.OnDieEvent -= OnEnemyDie;
        _currentAliveEnemyCount--;
        if (_currentAliveEnemyCount == 0)
        {
            OnWaveEnd();
        }
    }

    private void OnWaveEnd()
    {
        // If waves is end
        if (_currentEnemyWaveIndex == EnemyWaves.Count - 1)
        {
            OnLevelEnd?.Invoke();
            return;
        }
        
        GenerateNextWave();
    }
}