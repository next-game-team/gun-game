public class ControlTutorialManager : Singleton<ControlTutorialManager>
{
    private bool _isMove;
    private bool _isAttack;
    
    private void Start()
    {
        // Turn on Control tutorial
        GameObjectOnSceneManager.Instance.CanvasController.ControlTutorial.gameObject.SetActive(true);
        
        // Subscribe on player first move and attack
        GameObjectOnSceneManager.Instance
            .Player.GetComponent<PlayerMoveController>().MoveCallEvent.AddListener(OnPlayerMoveCall);
        GameObjectOnSceneManager.Instance
            .Player.GetComponent<PlayerAttackController>().OnAttackStartEvent += OnPlayerAttackCall;
    }

    // Method called when player call move for the first time
    private void OnPlayerMoveCall(DirectionEnum directionEnum)
    {
        GameObjectOnSceneManager.Instance.CanvasController
            .ControlTutorial.SwipeScreen.gameObject.SetActive(false);
        
        _isMove = true;
        GameObjectOnSceneManager.Instance
            .Player.GetComponent<PlayerMoveController>().MoveCallEvent.RemoveListener(OnPlayerMoveCall);
        CheckTutorialComplete();
    }

    // Method called when player call attack for the first time
    private void OnPlayerAttackCall()
    {
        GameObjectOnSceneManager.Instance.CanvasController
            .ControlTutorial.AttackScreen.gameObject.SetActive(false);
        
        _isAttack = true;
        GameObjectOnSceneManager.Instance
            .Player.GetComponent<PlayerAttackController>().OnAttackStartEvent -= OnPlayerAttackCall;
        CheckTutorialComplete();
    }

    private void CheckTutorialComplete()
    {
        // Turn off tutorial if it was completed
        if (_isMove && _isAttack)
        {
            GameObjectOnSceneManager.Instance.CanvasController
                .ControlTutorial.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    
}
