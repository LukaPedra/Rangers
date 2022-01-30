using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject cellphonePanel;
	[SerializeField] GameObject InteractionMenu;

	private bool isMenuOpen;

	private void Start() {
		cellphonePanel.SetActive(false);
		isMenuOpen = false;
		GameStateManager.Instance.SetState(GameState.Class);
	}

	public void OpenCellphone() {
		if (!SchoolClasses.DoesAllowPhone(SchoolClassManager.Instance.CurrentClass))
			return;

		isMenuOpen = true;//Somente para desabilitar o menu de abrir
		GameStateManager.Instance.SetState(GameState.Phone);
		cellphonePanel.SetActive(true);
	}

	public void CloseCellphone() {
		isMenuOpen = false; //Somente para desabilitar o menu de abrir
		GameStateManager.Instance.SetState(GameState.Class);
		cellphonePanel.SetActive(false);
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

