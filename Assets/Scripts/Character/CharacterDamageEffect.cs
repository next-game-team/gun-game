using DG.Tweening;
using UnityEngine;

public class CharacterDamageEffect : DamageEffect
{
    [SerializeField] 
    private float _recoilPower = 2f;

    [SerializeField] 
    private float _recoilDuration = 0.5f;

    [SerializeField]
    private bool _isRandomShake;
    
    public override void OnDamageReceived(Damageble damageble, DamageInfo damageInfo)
    {
        if (_isRandomShake)
        {
            RandomShake(damageble);
        }
        else
        {
            DirectionShake(damageble, damageInfo);
        }
    }

    private void DirectionShake(Damageble damageble, DamageInfo damageInfo)
    {
        var characterPositionX = damageble.transform.position.x;
        // Calculate position to recoil
        var isDamageFromRight = characterPositionX <= damageInfo.AssaulterPosition.x ? -1 : 1;  
        
        var sequence = DOTween.Sequence();
        sequence.Append(damageble.transform.DOMoveX(characterPositionX
                                                    + isDamageFromRight * _recoilPower, _recoilDuration))
            .Append(damageble.transform.DOMoveX(characterPositionX, _recoilDuration));
    }

    private void RandomShake(Damageble damageble)
    {
        damageble.transform.DOShakePosition(_recoilDuration, Vector2.right * _recoilPower);
    }
}