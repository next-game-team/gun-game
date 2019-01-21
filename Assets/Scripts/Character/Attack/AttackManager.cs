using UnityEngine;

public class AttackManager<T> : MonoBehaviour where T : AttackController
{
    [SerializeField]
    private Gun _gun;
    
    protected T AttackController;
    
    protected virtual void Awake()
    {   
        AttackController = GetComponent<T>();

        if (_gun == null)
        {
            Debug.LogWarning("There is no gun on Character: " + gameObject.name);
            return;
        }
        
        AttackController.AttackEvent.AddListener(OnAttackEvent);
    }

    protected virtual void OnAttackEvent()
    {
        _gun.Shoot();
    }
}