using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenCloseScene : MonoBehaviour
{
	public void OpenScene(string sceneName)
	{
		CustomSceneManager.Instance.ChangeScene(sceneName);
	}


	public void CloseThisScene()
	{
		CustomSceneManager.Instance.ChangeSceneToMain();
	}
}
