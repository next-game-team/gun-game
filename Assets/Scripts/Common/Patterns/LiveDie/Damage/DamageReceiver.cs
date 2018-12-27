using UnityEngine;

[RequireComponent(typeof(Liveble))]
public class DamageReceiver : MonoBehaviour
{

	private Liveble _liveble;
	private DamageEffect _damageEffect;
	
	// Use this for initialization
	private void Awake()
	{
		_liveble = GetComponent<Liveble>();
		_damageEffect = GetComponent<DamageEffect>();
	}

	public void ReceiveDamage(DamageInfo damageInfo)
	{
		_liveble.DecreaseHp(damageInfo.DamageCount);
		if (!_liveble.IsAlive()) return;
		
		if (_damageEffect == null)
		{
			Debug.LogError("There is no damage effect for " + gameObject.name);
		}
		else
		{
			_damageEffect.OnDamageReceived(damageInfo);
		}
	}
	
}
