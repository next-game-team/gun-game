using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;

[RequireComponent(typeof(Platform))]
public class PlatformNeighborsFinder : MonoBehaviour
{

	[SerializeField]
	private float _raycastLength;

	private readonly IEnumerable<TagEnum> _neighborTags = new List<TagEnum>() 
		{TagEnum.Platform};
	
	public void FindNeighbors()
	{
		var thisPlatform = GetComponent<Platform>();

		var neighbors = new PlatformNeighbors(
			FindNeighborByDirection(Vector2.left), 
			FindNeighborByDirection(Vector2.right), 
			FindNeighborByDirection(Vector2.up), 
			FindNeighborByDirection(Vector2.down)
			);
		
		thisPlatform.Neighbors = neighbors;
	}

	private Platform FindNeighborByDirection(Vector3 direction)
	{
		RaycastHit hit;
		if (Physics.Raycast(gameObject.transform.position, direction, out hit, _raycastLength)) 
		{
			// Check if intersected object is Platform
			if (TagUtils.CompareTagWithTagsList(hit.transform.tag, _neighborTags))
			{
				return hit.transform.gameObject.GetComponent<Platform>();
			}
		}
		
		return null;
	}
	
}
