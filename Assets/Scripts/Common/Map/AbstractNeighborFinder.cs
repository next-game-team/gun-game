using UnityEngine;

public abstract class AbstractNeighborFinder : MonoBehaviour
{
    [SerializeField]
    private float _raycastLength;
    public float RaycastLength => _raycastLength;

    [SerializeField] private LayerMask _neighborLayerMask;
    public LayerMask NeighborLayerMask => _neighborLayerMask;
}