using UnityEngine;

public class DamageInfo
{
	public int DamageCount { get; set; }
	public Vector3 AssaulterPosition { get; private set; }

	public DamageInfo(int damageCount, Vector3 assaulterPosition)
	{
		DamageCount = damageCount;
		AssaulterPosition = assaulterPosition;
	}
	
	
}
