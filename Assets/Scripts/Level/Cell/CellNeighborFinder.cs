public class CellNeighborFinder : AbstractNeighborFinder
{
    public Cell FindNeighbor(Cell cell, DirectionEnum directionEnum)
    {
        return DirectionUtils.FindNeighbor(cell, directionEnum, RaycastLength, NeighborLayerMask);
    }
}