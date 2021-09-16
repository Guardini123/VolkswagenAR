using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUi : MonoBehaviour
{
    [SerializeField] private Button _btnInfo;
    [SerializeField] private GameObject _taskInfo;
    [SerializeField] private GameObject _picOpenInfo;
    [SerializeField] private GameObject _picCloseInfo;
    [SerializeField] private Transform _layout;

    [Space]
    [SerializeField] private string _keyForLoading;
    [SerializeField] private GameObject _picStatusUndone;
    [SerializeField] private GameObject _picStatusDone;


    void Start()
    {
        _btnInfo.onClick.AddListener(OpenTaskInfo);
    }


	private void OnEnable()
	{
        CheckTaskStatus();
	}


	public void CheckTaskStatus()
	{
        var username = SaverLoaderLocal.Instance.LoadString("active_user");
        if (SaverLoaderLocal.Instance.LoadInt(_keyForLoading, username) == 1)
        {
            _picStatusDone.SetActive(true);
            _picStatusUndone.SetActive(false);
        }
		else
		{
            _picStatusDone.SetActive(false);
            _picStatusUndone.SetActive(true);
        }
	}


	private void OpenTaskInfo()
	{
		if (_taskInfo.activeSelf)
		{
            _taskInfo.SetActive(false);
            _picCloseInfo.SetActive(false);
            _picOpenInfo.SetActive(true);
        }
		else
		{
            _taskInfo.SetActive(true);
            _picCloseInfo.SetActive(true);
            _picOpenInfo.SetActive(false);
        }


        UpdateLayout(_layout, 0);
	}


    /// <summary>
    /// Обновляет вёрстку в layout group
    /// </summary>
    /// <param name="layout"> Объект с компонентом layout group </param>
    /// <param name="layoutMode"> 0 - vertical, 1 - horizontal </param>
    private void UpdateLayout(Transform layout, int layoutMode)
    {
        if (layoutMode == 0)
        {
            var verticalLayout = layout.gameObject.GetComponent<VerticalLayoutGroup>();
            verticalLayout.CalculateLayoutInputVertical();
        }
        else if (layoutMode == 1)
        {
            var horizontalLayout = layout.gameObject.GetComponent<HorizontalLayoutGroup>();
            horizontalLayout.CalculateLayoutInputHorizontal();
        }
        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(layout.GetComponent<RectTransform>());
    }
}
