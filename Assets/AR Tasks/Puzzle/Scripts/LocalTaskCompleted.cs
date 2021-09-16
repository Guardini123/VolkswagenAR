using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;


public class LocalTaskCompleted : MonoBehaviour
{
    Dictionary<int, bool> tasks = new Dictionary<int, bool>();

    public UnityEvent OnTaskComplited;


    private void Start()
    {
        tasks.Add(0, false);
        tasks.Add(1, false);
    }

    public void PartTaskCompleted(int id, bool result)
    {
        Debug.Log("Task status update");
		if (tasks[id] != result)
		{
			tasks[id] = result;

			foreach (KeyValuePair<int, bool> task in tasks)
			{
				if (!task.Value)
					return;
			}


			OnTaskComplited?.Invoke();
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        if (transform.GetChild(0).gameObject.activeSelf)
            transform.GetChild(0).gameObject.SetActive(false);

        foreach (int key in tasks.Keys.ToList())
            tasks[key] = false;
    }
}
