using UnityEngine;

[RequireComponent(typeof(Liveble))]
public class Damageble : MonoBehaviour
{
	public delegate void DamageEvent(Damageble damageble, DamageInfo damageInfo);
	public event DamageEvent OnDamageEvent;
	
	private Liveble _liveble;
	
	// Use this for initialization
	private void Awake()
	{
		_liveble = GetComponent<Liveble>();
	}

	public void ReceiveDamage(DamageInfo damageInfo)
	{
		_liveble.DecreaseHp(damageInfo.DamageCount);

		if (_liveble.IsAlive())
		{
			OnDamageEvent?.Invoke(this, damageInfo);	
		}
	}
	
}
