using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private LevelConfig _startLevelConfig;
    
    [SerializeField]
    private Level _currentLevel;
    public Level CurrentLevel => _currentLevel; 
    
    private LevelConfig _currentLevelConfig;

    private void Awake()
    {
        _currentLevelConfig = Instantiate(_startLevelConfig);
    }

    public void GenerateNextLevel()
    {
        LevelGenerator.GenerateWithConfig(_currentLevelConfig, _currentLevel);
    }
}