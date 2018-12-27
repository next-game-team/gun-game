using UnityEngine;

[RequireComponent(typeof(Dieble))]
public class Liveble : MonoBehaviour
{
	public HpConfig HpConfig;
	public int CurrentHp { get; private set; }
	private Dieble _dieble;

	private bool _isAlive = true;

	public bool IsAlive()
	{
		return _isAlive;
	}

	private void Awake()
	{
		_dieble = GetComponent<Dieble>();
	}

	public void InitHp()
	{
		CurrentHp = HpConfig.Hp;
		_isAlive = true;
		Debug.Log(this + "Init HP: " + CurrentHp);
	}

	public void IncreaseHp(int hp)
	{
		CurrentHp = Mathf.Clamp(CurrentHp + hp, 0, HpConfig.Hp);
		OnHpUpdated();
	}
		
	public void DecreaseHp(int hp)
	{
		CurrentHp = Mathf.Clamp(CurrentHp - hp, 0, HpConfig.Hp);
		OnHpUpdated();
	}

	private void OnHpUpdated()
	{
		Debug.Log(this + "Current HP: " + CurrentHp);
		CheckHp();
	}

	private void CheckHp()
	{
		if (CurrentHp <= 0)
		{
			_isAlive = false;
			_dieble.Die();
		}
	}
}