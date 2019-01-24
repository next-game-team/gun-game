using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CharacterMoveManager))]
public class CharacterDamageEffect : DamageEffect
{
    [SerializeField] 
    private float _recoilPower = 2f;

    [SerializeField] 
    private float _recoilDuration = 0.5f;

    [SerializeField]
    private bool _isRandomShake;

    private CharacterMoveManager _moveManager;
    private PlatformObject _platformObject;
    private Sequence _currentSequence;

    protected override void Awake()
    {
        base.Awake();
        _moveManager = GetComponent<CharacterMoveManager>();
        _platformObject = GetComponent<PlatformObject>();
        _moveManager.OnMoveEvent += CancelEffectOnAnotherMove;
    }

    public override void OnDamageReceived(Damageble damageble, DamageInfo damageInfo)
    {
        CancelEffectOnAnotherMove(); // Cancel previous damage effect
        
        // Skip effect if object is already moving
        if (_platformObject.IsInMove) return;
        
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
        var characterPositionX = damageble.transform.localPosition.x;
        // Calculate position to recoil
        var isDamageFromRight = characterPositionX <= damageInfo.AssaulterPosition.x ? -1 : 1;  
        
        _currentSequence = DOTween.Sequence();
        _currentSequence.Append(damageble.transform.DOLocalMoveX(characterPositionX
                                                    + isDamageFromRight * _recoilPower, _recoilDuration))
            .Append(damageble.transform.DOLocalMoveX(characterPositionX, _recoilDuration));
    }

    private void RandomShake(Damageble damageble)
    {
        damageble.transform.DOShakePosition(_recoilDuration, Vector2.right * _recoilPower);
    }

    private void CancelEffectOnAnotherMove()
    {
        // If damage effect is playing then stop it
        if (_currentSequence != null && _currentSequence.IsActive())
        {
            _currentSequence.Complete();
        }
    }
}