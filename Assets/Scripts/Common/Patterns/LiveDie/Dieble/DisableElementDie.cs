using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableElementDie : Dieble {

    [SerializeField]
    private float _animationTimer;
    private bool _isDie;
    private float _timer;
    private bool _alreadyDie = false;

	public override void Die()
	{
	    if (_alreadyDie) return;
	    base.Die();
	    
        GetComponent<Animator>().SetTrigger("Die");
        _timer = _animationTimer;
        _isDie = false;
	    _alreadyDie = true;
	    //gameObject.SetActive(false);
	}

    private void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
            _isDie = false;
        }
        if(_timer < 0)
        {
            _isDie = true;
        }
        if (_timer < 0 && _isDie)
            gameObject.SetActive(false);
    }
}
