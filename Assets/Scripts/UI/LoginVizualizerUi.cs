using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(TMP_Text))]
public class LoginVizualizerUi : MonoBehaviour
{
	private TMP_Text _login;
	

	void Awake()
	{
		_login = this.gameObject.GetComponent<TMP_Text>();
	}


	private void OnEnable()
	{
		_login.text = SaverLoaderLocal.Instance.LoadString("active_user");
	}
}
