using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleChecker : MonoBehaviour
{
    [SerializeField] private List<bool> _checks;

	[SerializeField] private bool _useOrder;

	public UnityEvent OnChecksReady;


    public void SetChecker(int num)
	{
		if (num < 0) return;

		if (num >= _checks.Count) return;

		if (_useOrder)
			if (num != 0)
				if (!_checks[num - 1])
					return;

		_checks[num] = true;
	}


	public bool Check()
	{
		foreach(var check in _checks)
		{
			if (!check) return false;
		}
		OnChecksReady?.Invoke();
		return true;
	}
}
