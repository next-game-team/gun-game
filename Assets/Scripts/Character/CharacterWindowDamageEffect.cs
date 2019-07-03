using DG.Tweening;
using UnityEngine;

public class CharacterWindowDamageEffect : DamageEffect
{

    [SerializeField] private Color _damageColor;
    [SerializeField] private float _damageDuration;
    [SerializeField] private CharacterWindow _window;
    
    public override void OnDamageReceived(Damageble damageble, DamageInfo damageInfo)
    {
        DOTween.Sequence()
            .Append(_window.SpriteRenderer.DOColor(_damageColor, _damageDuration))
            .Append(_window.SpriteRenderer.DOColor(_window.DefaultColor, _damageDuration))
            .Play();
    }
}