using UnityEngine;

public abstract class DamageEffect : MonoBehaviour
{

    public abstract void OnDamageReceived(DamageInfo damageInfo);
}
