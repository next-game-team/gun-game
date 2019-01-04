﻿using UnityEngine;

public class PlayerStartPositionController : MonoBehaviour
{
    [SerializeField]
    private Platform _startPlatform;

    [SerializeField] 
    private PlatformObject _player;

    private void Awake()
    {
        if (_startPlatform == null || _player == null)
        {
            Debug.LogWarning("PlayerStartPositionController doesn't have objects");
            return;
        }

        _startPlatform.SetPlatformObject(_player);
    }
}
