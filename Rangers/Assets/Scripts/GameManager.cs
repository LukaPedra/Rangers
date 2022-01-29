using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject cellphonePanel;

	private bool isCellphoneOpen;

	private void Start() {
		isCellphoneOpen = false;
		cellphonePanel.SetActive(false);
	}

	public void OpenCellphone() {
		isCellphoneOpen = true;
		cellphonePanel.SetActive(isCellphoneOpen);
	}

	public void CloseCellphone() {
		isCellphoneOpen = false;
		cellphonePanel.SetActive(isCellphoneOpen);
	}
}

