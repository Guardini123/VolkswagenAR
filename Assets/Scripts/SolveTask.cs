using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SolveTask : MonoBehaviour
{
    public UnityEvent OnSolveTask;

    [SerializeField] private string _keyForTask;
    

    public void Solve()
	{
        var username = SaverLoaderLocal.Instance.LoadString("active_user");
        SaverLoaderLocal.Instance.SaveInt(1, _keyForTask, username);
        OnSolveTask?.Invoke();
	}
}
