public class PlatformNeighborsFinder : AbstractNeighborFinder
{
	
	public void FindNeighbors(Platform platform)
	{
		var neighbors = new Neighbors<Platform>(
			FindNeighbor(platform, DirectionEnum.LEFT), 
			FindNeighbor(platform, DirectionEnum.RIGHT), 
			FindNeighbor(platform, DirectionEnum.UP), 
			FindNeighbor(platform, DirectionEnum.DOWN)
		);
		
		platform.Neighbors = neighbors;
	}

	private Platform FindNeighbor(Platform platform, DirectionEnum direction)
	{
		return DirectionUtils.FindNeighbor<Platform, PlatformType>(platform, direction,
			RaycastLength, NeighborLayerMask);
	}
	
}
