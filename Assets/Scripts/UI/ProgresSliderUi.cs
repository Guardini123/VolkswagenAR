using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(Slider))]
public class ProgresSliderUi : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private List<string> _tasksKeys;

    [Space]
    [SerializeField] private TMP_Text _actionForTasks;
    [SerializeField] private string _startText;
    [SerializeField] private string _progressText;
    [SerializeField] private string _endText;

    private float _step;
    private float _countPerformedTasks;


    void Awake()
    {
        _slider = this.gameObject.GetComponent<Slider>();
        _step = 1.0f / _tasksKeys.Count;
    }


	private void OnEnable()
	{
        CheckProgres();
    }


    public void CheckProgres()
	{
        _actionForTasks.text = _startText;

        var username = SaverLoaderLocal.Instance.LoadString("active_user");

        _slider.value = 0.0f;
        _countPerformedTasks = 0;

        for (int i = 0; i < _tasksKeys.Count; i++)
        {
            if (SaverLoaderLocal.Instance.LoadInt(_tasksKeys[i], username) == 1)
            {
                _slider.value += _step;
                _countPerformedTasks++;
            }
        }

        if (_countPerformedTasks > 0) _actionForTasks.text = _progressText;
        if (_countPerformedTasks == _tasksKeys.Count) _actionForTasks.text = _endText;
    } 
}
