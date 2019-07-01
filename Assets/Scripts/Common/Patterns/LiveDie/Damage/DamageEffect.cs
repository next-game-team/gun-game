using UnityEngine;

[RequireComponent(typeof(Damageble))]
public abstract class DamageEffect : MonoBehaviour
{
    public abstract void OnDamageReceived(Damageble damageble, DamageInfo damageInfo);

    protected virtual void Awake()
    {
        GetComponent<Damageble>().OnDamageEvent += OnDamageReceived;
    }
}
