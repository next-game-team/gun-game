using UnityEngine;

public class PlayerCollectableController : MonoBehaviour, ICollectableController
{
    public virtual void Collect(CollectableObject collectableObject)
    {
        switch (collectableObject.Type)
        {
            case CollectableType.LevelStarter:
                LevelManager.Instance.GenerateNextLevel();
                LevelManager.Instance.CurrentLevel.StartLevel();
                break;
        }
    }
}