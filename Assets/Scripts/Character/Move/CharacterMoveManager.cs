using UnityEngine;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(PlatformObject))]
public class CharacterMoveManager : MonoBehaviour
{
    [SerializeField] private MoveConfig _moveConfig;
    
    private MoveController _moveController;
    private PlatformObject _platformObject;

    private bool _isMoveCooldown;
    public bool IsMoveCooldown => _isMoveCooldown;
    
    private float _currentCooldownTime;

    public delegate void MoveEvent();
    public event MoveEvent OnMoveEvent;
    
    private void Awake()
    {
        _platformObject = GetComponent<PlatformObject>();
        
        _moveController = GetComponent<MoveController>();
        _moveController.MoveCallEvent.AddListener(OnMoveCallEvent);
    }

    private void OnEnable()
    {
        SetCooldown();
    }

    private void OnMoveCallEvent(DirectionEnum directionEnum)
    {
        if(_isMoveCooldown) return;

        var moveResult = BetweenPlatformMover.MoveTo(_platformObject, directionEnum);
        if (moveResult == false) return;
        OnMoveEvent?.Invoke();
        
        SetCooldown(); 
    }

    private void Update()
    {
        if (!_isMoveCooldown) return;

        if (_isMoveCooldown && _currentCooldownTime > 0)
        {
            _currentCooldownTime -= Time.deltaTime;
        }
        else
        {
            _isMoveCooldown = false;
        }

    }
    
    private void SetCooldown()
    {
        _isMoveCooldown = true;
        _currentCooldownTime = _moveConfig.CooldownTime;
    }
    
}
