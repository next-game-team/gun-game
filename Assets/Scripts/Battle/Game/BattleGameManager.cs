using UnityEngine;

public class BattleGameManager : AbstractGameManager<BattleGameManager>
{
    private Liveble _playerLiveble;
    private Dieble _playerDieble;
    private PlayerAttackManager _playerAttackManager;

    private void Awake()
    {
        _playerLiveble = GameObjectOnSceneManager.Instance.Player.GetComponent<Liveble>();
        if (_playerLiveble != null) _playerLiveble.OnDieEvent += OnPlayerDeath; // Subscribe on player death event
        _playerAttackManager = GameObjectOnSceneManager.Instance.Player.GetComponent<PlayerAttackManager>();
    }

    private void OnPlayerDeath(Liveble liveble)
    {
        PauseTime();
        GameObjectOnSceneManager.Instance.CanvasController.DeathScreen.SetActive(true);
    }

    public void ContinueGame() //Add HP
    {
        ResumeTime();
        _playerLiveble.InitHp();
        GameObjectOnSceneManager.Instance.Player.GetComponent<HpLampController>().InitLamps();
        GameObjectOnSceneManager.Instance.CanvasController.DeathScreen.SetActive(false);
    }

    protected override void PauseTime()
    {
        base.PauseTime();
        
        // Cancel player attack
        if (_playerAttackManager.IsInAttack)
        {
            Debug.Log("Cancel player attack on pausing time");
            _playerAttackManager.CancelAttack();
        }
    }
}
