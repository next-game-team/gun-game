using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public delegate void LevelEndEvent();
    public event LevelEndEvent OnLevelEnd;
    
    public List<EnemyWaveConfig> EnemyWaves { get; set; }

    [SerializeField] 
    private ImageAmountController _waveLineImageController;
    
    [SerializeField] private TextWaveController _waveTextInfo;

    private float _timeBetweenWaves = 2f;
    
    private bool _isPlayed;
    private int _currentAliveEnemyCount;
    private int _currentEnemyWaveIndex;

    private void Awake()
    {
        CheckInitialization();
    }

    private void CheckInitialization()
    {
        if (_waveLineImageController == null)
        {
            Debug.LogError("ImageAmountController isn't set for WaveLineImage");
        }

        if(_waveTextInfo == null)
        {
            Debug.LogError("TextWaveController isn't set for TextWaveInfo");
        }
    }

    public void StartLevel()
    {
        // Set level played from first wave
        _isPlayed = true;
        _currentEnemyWaveIndex = -1;
        
        _waveLineImageController.gameObject.transform.parent.gameObject.SetActive(true);
        _waveLineImageController.Init(EnemyWaves.Count);
        _waveLineImageController.SetImageAmount(0);
        _waveTextInfo.SetWaveNumText(_currentEnemyWaveIndex + 1, 3);
        
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
        
        _waveLineImageController.SetImageAmount(_currentEnemyWaveIndex + 1);
        _waveTextInfo._starNextWave = true;
        _waveTextInfo.SetWaveNumText(_currentEnemyWaveIndex + 1, 3);
    }

    private void OnEnemyDie(Liveble enemyLiveble)
    {
        enemyLiveble.OnDieEvent -= OnEnemyDie;
        _currentAliveEnemyCount--;
        if (_currentAliveEnemyCount == 0)
        {
            StartCoroutine(OnWaveEnd());
        }
    }

    private IEnumerator OnWaveEnd()
    {
        // If waves is end
        if (_currentEnemyWaveIndex == EnemyWaves.Count - 1)
        {
            _waveLineImageController.gameObject.transform.parent.gameObject.SetActive(false);
            OnLevelEnd?.Invoke();
            yield break;
        }
        
        yield return new WaitForSeconds(_timeBetweenWaves); // Wait before start next wave
        GenerateNextWave();
    }
}