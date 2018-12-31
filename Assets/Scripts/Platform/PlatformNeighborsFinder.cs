using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;

public class PlatformNeighborsFinder : MonoBehaviour
{

	[SerializeField]
	private float _raycastLength;

	[SerializeField] private LayerMask _neighborLayerMask;
	
	public void FindNeighbors(Platform platform)
	{
		var neighbors = new PlatformNeighbors(
			FindNeighborByDirection(platform.SidePoints.Left, Vector2.left), 
			FindNeighborByDirection(platform.SidePoints.Right, Vector2.right), 
			FindNeighborByDirection(platform.SidePoints.Top, Vector2.up), 
			FindNeighborByDirection(platform.SidePoints.Bottom, Vector2.down)
			);
		
		platform.Neighbors = neighbors;
	}

	private Platform FindNeighborByDirection(Transform sidePoint, Vector3 direction)
	{
		var hit = Physics2D.Raycast(sidePoint.position, direction, _raycastLength, _neighborLayerMask);
		return hit.transform != null ? hit.transform.gameObject.GetComponent<Platform>() : null;
	}
	
}
