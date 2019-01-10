using UnityEngine;

[RequireComponent(typeof(Damageble))]
public abstract class DamageEffect : MonoBehaviour
{
    public abstract void OnDamageReceived(Damageble damageble, DamageInfo damageInfo);

    private void Awake()
    {
        GetComponent<Damageble>().OnDamageEvent += OnDamageReceived;
    }
}
