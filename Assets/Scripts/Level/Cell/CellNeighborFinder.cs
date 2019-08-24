public class CellNeighborFinder : AbstractNeighborFinder
{
    public Cell FindNeighbor(Cell cell, DirectionEnum directionEnum)
    {
        return DirectionUtils.FindNeighbor<Cell, CellType>(cell, directionEnum, RaycastLength, NeighborLayerMask);
    }
}