using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject cellphonePanel;
	[SerializeField] GameObject InteractionMenu;

	private bool isCellphoneOpen;
	private bool isMenuOpen;

	private void Start() {
		isCellphoneOpen = false;
		cellphonePanel.SetActive(false);
		isMenuOpen = false;
	}

	public void OpenCellphone() {
		isMenuOpen = true;//Somente para desabilitar o menu de abrir
		isCellphoneOpen = true;
		cellphonePanel.SetActive(isCellphoneOpen);
	}

	public void CloseCellphone() {
		isMenuOpen = false; //Somente para desabilitar o menu de abrir
		isCellphoneOpen = false;
		cellphonePanel.SetActive(isCellphoneOpen);
	}
	public bool GetMenuStatus(){
		return isMenuOpen;
	}
	public bool OpenMenu(){
        isMenuOpen = true;
		return isMenuOpen;
    }
    public bool CloseMenu(){
        isMenuOpen = false;
		return isMenuOpen;
    }
	public void SetMenuBool(bool paramenter){
		isMenuOpen = paramenter;
	}
	
}

