using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SimpleLoginUi : MonoBehaviour
{
    [SerializeField] private TMP_InputField _loginIF;
    [SerializeField] private Button _enterBtn;
    [SerializeField] private GameObject _loginUI;
    [SerializeField] private GameObject _uiAfterLogin;


    void Start()
    {
        _enterBtn.onClick.AddListener(Enter);
        Enter();
    }


	private void Enter()
	{
		if (SaverLoaderLocal.Instance.LoadString("active_user").Equals(""))
		{
			if (_loginIF.text.Equals(""))
			{
                return;
			}

            SaverLoaderLocal.Instance.SaveString(_loginIF.text, "active_user");
		}

        _uiAfterLogin.SetActive(true);
        _loginUI.SetActive(false);
	}
}
