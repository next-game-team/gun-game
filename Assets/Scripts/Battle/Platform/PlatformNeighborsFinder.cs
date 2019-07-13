public class PlatformNeighborsFinder : AbstractNeighborFinder
{
	
	public void FindNeighbors(Platform platform)
	{
		var neighbors = new PlatformNeighbors(
			DirectionUtils.FindNeighbor(platform, DirectionEnum.LEFT,
				RaycastLength, NeighborLayerMask), 
			DirectionUtils.FindNeighbor(platform, DirectionEnum.RIGHT,
				RaycastLength, NeighborLayerMask), 
			DirectionUtils.FindNeighbor(platform, DirectionEnum.UP,
				RaycastLength, NeighborLayerMask), 
			DirectionUtils.FindNeighbor(platform, DirectionEnum.DOWN,
				RaycastLength, NeighborLayerMask)
			);
		
		platform.Neighbors = neighbors;
	}

	
	
}
