using UnityEngine;

public abstract class PlayerCollectableController : MonoBehaviour, ICollectableController
{
    public abstract void Collect(CollectableObject collectableObject);
}