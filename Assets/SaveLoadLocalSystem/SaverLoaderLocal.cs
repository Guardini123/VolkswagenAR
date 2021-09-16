using System.Collections;
using UnityEngine;


public class SaverLoaderLocal : MonoBehaviour
{
	public static SaverLoaderLocal Instance { get; private set; }


	private void Awake()
	{
		if (Instance != null)
		{
			GameObject.Destroy(this.gameObject);
		}

		Instance = this;
		DontDestroyOnLoad(this);
	}




	//--------------------------------------------------------CLEAR-------------------------------------------------------------------


	/// <summary>
	/// �������� ����������
	/// </summary>
	public void ClearSavedData()
	{
		PlayerPrefs.DeleteAll();
	}


	/// <summary>
	/// �������� ����������
	/// </summary>
	/// <param name="key"> ���� </param>
	public void ClearSavedData(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}


	/// <summary>
	/// �������� ����������
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	public void ClearSavedData(string key, string username)
	{
		var bufKey = key + ":" + username;
		PlayerPrefs.DeleteKey(bufKey);
	}







	//------------------------------------------------------------CHECK---------------------------------------------------------------



	/// <summary>
	/// ���������, ������� �� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <returns> true- ���� ����������, false - ��� ��� </returns>
	public bool CheckKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}


	/// <summary>
	/// ���������, ������� �� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������ </param>
	/// <returns> true- ���� ����������, false - ��� ��� </returns>
	public bool CheckKey(string key, string username)
	{
		var bufKey = key + ":" + username;
		return CheckKey(bufKey);
	}








	//-----------------------------------------------------SAVE-------------------------------------------------------





	/// <summary>
	/// ��������� �������� float � ������ �� ����� 
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	public void SaveFloat(float value, string key)
	{
		PlayerPrefs.SetFloat(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// ��������� �������� float � ������ �� ����� � ����� ������������
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	public void SaveFloat(float value, string key, string username)
	{
		var bufKey = key + ":" + username;
		SaveFloat(value, bufKey);
	}


	/// <summary>
	/// ��������� �������� int � ������ �� ����� 
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	public void SaveInt(int value, string key)
	{
		PlayerPrefs.SetInt(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// ��������� �������� int � ������ �� ����� � ����� ������������
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	public void SaveInt(int value, string key, string username)
	{
		var bufKey = key + ":" + username;
		SaveInt(value, bufKey);
	}


	/// <summary>
	/// ��������� �������� string � ������ �� ����� 
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	public void SaveString(string value, string key)
	{
		PlayerPrefs.SetString(key, value);
		PlayerPrefs.Save();
	}


	/// <summary>
	/// ��������� �������� int � ������ �� ����� � ����� ������������
	/// </summary>
	/// <param name="value"> �������� </param>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	public void SaveString(string value, string key, string username)
	{
		var bufKey = key + ":" + username;
		SaveString(value, bufKey);
	}







	//------------------------------------------LOAD---------------------------------------------------------------------------



	/// <summary>
	/// ��������� �������� float
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <returns> �������� </returns>
	public float LoadFloat(string key)
	{
		return PlayerPrefs.GetFloat(key);
	}


	/// <summary>
	/// ��������� �������� float
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <returns> �������� </returns>
	public float LoadFloat(string key, string username)
	{
		var bufKey = key + ":" + username;
		return LoadFloat(bufKey);
	}


	/// <summary>
	/// ��������� �������� int
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <returns> �������� </returns>
	public int LoadInt(string key)
	{
		return PlayerPrefs.GetInt(key);
	}


	/// <summary>
	/// ��������� �������� int
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <returns> �������� </returns>
	public int LoadInt(string key, string username)
	{
		var bufKey = key + ":" + username;
		return LoadInt(bufKey);
	}


	/// <summary>
	/// ��������� �������� string
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <returns> �������� </returns>
	public string LoadString(string key)
	{
		return PlayerPrefs.GetString(key);
	}


	/// <summary>
	/// ��������� �������� string
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <returns> �������� </returns>
	public string LoadString(string key, string username)
	{
		var bufKey = key + ":" + username;
		return LoadString(bufKey);
	}






	//-------------------------------------------TRYLOAD------------------------------------------------------------



	/// <summary>
	/// ��������� �������� float �� ����� � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� </returns>
	public bool TryLoadFloat(string key, out float value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = 0.0f;
			return false;
		}

		value = PlayerPrefs.GetFloat(key);
		return true;
	}


	/// <summary>
	/// ��������� �������� float �� ����� � ����� ������������ � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� � ����� </returns>
	public bool TryLoadFloat(string key, string username, out float value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoadFloat(bufKey, out value, out error);
	}


	/// <summary>
	/// ��������� �������� int �� ����� � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� </returns>
	public bool TryLoadInt(string key, out int value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = 0;
			return false;
		}

		value = PlayerPrefs.GetInt(key);
		return true;
	}


	/// <summary>
	/// ��������� �������� int �� ����� � ����� ������������ � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� � ����� </returns>
	public bool TryLoadInt(string key, string username, out int value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoadInt(key, out value, out error);
	}


	/// <summary>
	/// ��������� �������� string �� ����� � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� </returns>
	public bool TryLoadString(string key, out string value, out string error)
	{
		error = null;

		if (!PlayerPrefs.HasKey(key))
		{
			error = "Hasn't that key for saving: " + key + "!";
			Debug.Log(error);
			value = "";
			return false;
		}

		value = PlayerPrefs.GetString(key);
		return true;
	}


	/// <summary>
	/// ��������� �������� string �� ����� � ����� ������������ � ������� ������, ���� ����
	/// </summary>
	/// <param name="key"> ���� </param>
	/// <param name="username"> ��� ������������ </param>
	/// <param name="value"> �������� </param>
	/// <param name="error"> ������. ���� ������ �� ����, ����� null </param>
	/// <returns> �������� �� ����� � ����� </returns>
	public bool TryLoadString(string key, string username, out string value, out string error)
	{
		var bufKey = key + ":" + username;
		return TryLoadString(key, out value, out error);
	}
}