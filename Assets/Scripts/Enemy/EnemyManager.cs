using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField, ReadOnly]
    private GameObject _player;

    public GameObject Player => _player;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _player = GameObjectOnSceneManager.Instance.Player;
    }
}
