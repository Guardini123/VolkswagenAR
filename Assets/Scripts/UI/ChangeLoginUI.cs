using System.Collections;
using UnityEngine;


public class ChangeLoginUI : MonoBehaviour
{
	[SerializeField] private GameObject _sideMenuUi;
	[SerializeField] private GameObject _mainUi;
	[SerializeField] private GameObject _loginUi;

	public void ChangeLogin() 
	{
		SaverLoaderLocal.Instance.SaveString("", "active_user");
		_sideMenuUi.SetActive(false);
		_mainUi.SetActive(false);
		_loginUi.SetActive(true);
	}
}
