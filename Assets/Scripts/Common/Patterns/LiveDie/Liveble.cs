using UnityEngine;

[RequireComponent(typeof(Dieble))]
public class Liveble : MonoBehaviour
{
	[SerializeField] private HpConfig _hpConfig;

	public HpConfig HpConfig
	{
		get { return _hpConfig; }
		set { _hpConfig = value; }
	}

	[SerializeField, ReadOnly]
	private int _currentHp;
	
	public int CurrentHp
	{
		get { return _currentHp; }
		private set { _currentHp = value; }
	}

	public delegate void HpUpdateEvent(Liveble liveble, int hpDelta);
	public event HpUpdateEvent OnHpUpdateEvent;
	
	private Dieble _dieble;
	private bool _isAlive = true;

	public bool IsAlive()
	{
		return _isAlive;
	}

	private void Awake()
	{
		_dieble = GetComponent<Dieble>();
		InitHp();
	}

	public void InitHp()
	{
		CurrentHp = _hpConfig.Hp;
		_isAlive = true;
		Debug.Log(this + "Init HP: " + CurrentHp);
	}

	public void IncreaseHp(int delta)
	{
		CurrentHp = Mathf.Clamp(CurrentHp + delta, 0, _hpConfig.Hp);
		OnHpUpdateEvent?.Invoke(this, delta);
	}
		
	public void DecreaseHp(int delta)
	{
		delta = Mathf.Abs(delta);
		CurrentHp = Mathf.Clamp(CurrentHp - delta, 0, _hpConfig.Hp);
		OnHpUpdated(-delta);
	}

	private void OnHpUpdated(int delta)
	{
		Debug.Log(this + "Current HP: " + CurrentHp);
		CheckHp();
		OnHpUpdateEvent?.Invoke(this, delta);
	}

	private void CheckHp()
	{
		if (CurrentHp > 0) return;
		
		_isAlive = false;
		_dieble.Die();
	}
}