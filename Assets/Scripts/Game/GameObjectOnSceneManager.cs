using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectOnSceneManager : Singleton<GameObjectOnSceneManager>
{
    public GameObject Player { get; private set; }
    
    public CanvasController CanvasController { get; private set; }
    
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag(TagUtils.GetTagNameByEnum(TagEnum.Player));
        CanvasController = GameObject.FindGameObjectWithTag(
            TagUtils.GetTagNameByEnum(TagEnum.Canvas)).GetComponent<CanvasController>();
    }
    
}
