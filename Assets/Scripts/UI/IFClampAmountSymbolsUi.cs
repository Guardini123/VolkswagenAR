using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(TMP_InputField))]
public class IFClampAmountSymbolsUi : MonoBehaviour
{
	private TMP_InputField _inputField;
	private string _inputBuf;

	[SerializeField] private TMP_Text _amountSymbolsText;
	[SerializeField] private string _separator;
	[SerializeField] private int _maxAvailableAmount;


	private void Start()
	{
		_inputField = this.gameObject.GetComponent<TMP_InputField>();
		_inputField.onValueChanged.AddListener(UpdateAmountSymbols);

		_amountSymbolsText.text = _inputField.text.Length.ToString() + _separator + _maxAvailableAmount.ToString();
	}


	private void UpdateAmountSymbols(string inputSymbols)
	{
		if(inputSymbols.Length > _maxAvailableAmount)
		{
			_inputField.text = _inputBuf;
			return;
		}

		_inputBuf = _inputField.text;
		_amountSymbolsText.text = inputSymbols.Length.ToString() + _separator + _maxAvailableAmount.ToString();
	}
}
