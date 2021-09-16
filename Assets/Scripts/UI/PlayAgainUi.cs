using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayAgainUi : MonoBehaviour
{
	[SerializeField] private List<string> _tasksKeys;
	[SerializeField] private List<TaskUi> _tasksUi;
	[SerializeField] private ProgresSliderUi _progresSliderUi;


	public void Replay()
	{
		var username = SaverLoaderLocal.Instance.LoadString("active_user");

		for (int i = 0; i < _tasksKeys.Count; i++)
		{
			SaverLoaderLocal.Instance.SaveInt(0, _tasksKeys[i], username);
		}

		foreach(var taskUi in _tasksUi)
		{
			taskUi.CheckTaskStatus();
		}

		_progresSliderUi.CheckProgres();
	}
}
