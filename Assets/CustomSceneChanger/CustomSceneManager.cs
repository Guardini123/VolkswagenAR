using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class CustomSceneManager : MonoBehaviour
{
    public static CustomSceneManager Instance { get; private set; }
    [SerializeField] private List<GameObject> _allObjectsToHide = new List<GameObject>();

    private List<string> _activeScenes = new List<string>();


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }


	private void OnDestroy()
	{
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
	}


	private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
        SceneManager.SetActiveScene(arg0);
	}


	/// <summary>
	/// Открыть новую сцену параллельно с начальной
	/// </summary>
	/// <param name="sceneName"> Имя сцены на открытие </param>
	public void ChangeScene(string sceneName)
    {
        foreach (var obj in _allObjectsToHide)
        {
            obj.SetActive(false);
        }
        _activeScenes.Add(sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }


    /// <summary>
    /// Открыть начальную сцену, закрыв остальные
    /// </summary>
    public void ChangeSceneToMain()
    {
        foreach (var sceneName in _activeScenes)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        _activeScenes.Clear();

        foreach (var obj in _allObjectsToHide)
        {
            obj.SetActive(true);
        }
    }
}