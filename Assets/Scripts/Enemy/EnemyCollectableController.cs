using UnityEngine;

public class EnemyCollectableController : MonoBehaviour, ICollectableController
{
    public void Collect(CollectableObject collectableObject)
    {
        switch (collectableObject.Type)
        {
            case CollectableType.LevelStarter:
                LevelManager.Instance.SetLevelStarterCollectable();
                break;
        }
    }
}