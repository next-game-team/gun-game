using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformNeighborsFinder : MonoBehaviour
{

	[SerializeField]
	private float _raycastLength;

	[SerializeField] 
	private bool _allowChecking; // Flag that shows if script can check neighbors

	private readonly IEnumerable<TagEnum> _neighborTags = new List<TagEnum>() 
		{TagEnum.Platform};
	
	private void OnValidate ()
	{
		if (!_allowChecking)
		{
			return;
		}
		
		var thisPlatform = GetComponent<Platform>();
		var sidePointList = thisPlatform.SidePointList;

		var neighbors = sidePointList
			.Select(sidePoint => sidePoint.position - transform.position) // Calculate direction
			.Select(FindNeighborByDirection) // Find all neighbors
			.Where(neighborPlatform => neighborPlatform != null) // Filter not null neighbors
			.ToList();
		
		thisPlatform.SetNeighbors(neighbors);
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
