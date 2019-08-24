using System.Collections;
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
        CurrentLevel.OnLevelEnd += SetLevelStarterCollectable;
    }

    private void Start()
    {
        SetLevelStarterCollectable();
    }

    public void SetLevelStarterCollectable()
    {
        StartCoroutine(SetLevelStarterCoroutine());
    }

    private IEnumerator SetLevelStarterCoroutine()
    {
        yield return new WaitForSeconds(1f);
        
        var freePlatform = PlatformUtils.GetRandomPlatformForCollectable();
        if (freePlatform == null) yield return null;
        
        freePlatform.SetType(PlatformType.Start);
    }
    
    public void GenerateNextLevel()
    {
        LevelGenerator.GenerateWithConfig(_currentLevelConfig, _currentLevel);
    }
}