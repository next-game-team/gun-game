using System.Collections;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private LevelConfig _startLevelConfig;
    
    [SerializeField]
    private Level _currentLevel;
    public Level CurrentLevel => _currentLevel;

    [SerializeField] 
    private CollectableObject _levelStarterCollectable; 
    
    private LevelConfig _currentLevelConfig;

    private void Awake()
    {
        _currentLevelConfig = Instantiate(_startLevelConfig);
        CurrentLevel.OnLevelEnd += SetLevelStarterCollectable;
        _levelStarterCollectable.gameObject.SetActive(true); // TODO: FIX IT!!!
    }

    private void Start()
    {
        _levelStarterCollectable.gameObject.SetActive(false);
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
        
        freePlatform.SetCollectableObject(_levelStarterCollectable);
        _levelStarterCollectable.gameObject.SetActive(true);
    }
    
    public void GenerateNextLevel()
    {
        LevelGenerator.GenerateWithConfig(_currentLevelConfig, _currentLevel);
    }
}