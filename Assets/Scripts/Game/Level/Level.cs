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
    
    [SerializeField] private TextWaveController _textWaveController;

    private float _timeBetweenWaves = 2f;

    public bool IsPlayed { get; private set; }

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

        if(_textWaveController == null)
        {
            Debug.LogError("TextWaveController isn't set for TextWaveInfo");
        }
    }

    public void StartLevel()
    {
        // Set level played from first wave
        IsPlayed = true;
        _currentEnemyWaveIndex = -1;
        
        _waveLineImageController.gameObject.transform.parent.gameObject.SetActive(true);
        _waveLineImageController.Init(EnemyWaves.Count);
        _waveLineImageController.SetImageAmount(0);
        
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
        _textWaveController.SetWaveNumText(_currentEnemyWaveIndex + 1, EnemyWaves.Count);
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
            // Turn off wave line
            _waveLineImageController.gameObject.transform.parent.gameObject.SetActive(false);
            _textWaveController.ClearText();

            IsPlayed = false;
            OnLevelEnd?.Invoke();
            yield break;
        }
        
        yield return new WaitForSeconds(_timeBetweenWaves); // Wait before start next wave
        GenerateNextWave();
    }
}