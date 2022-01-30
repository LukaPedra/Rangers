using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject cellphonePanel;
	[SerializeField] GameObject InteractionMenu;

	private bool isMenuOpen;
	private bool isCellOpen;

	private void Start() {
		isCellOpen = false;
		cellphonePanel.SetActive(isCellOpen);
		isMenuOpen = false;
		GameStateManager.Instance.SetState(GameState.Class);
	}

	public void OpenCellphone() {
		if (!SchoolClasses.DoesAllowPhone(SchoolClassManager.Instance.CurrentClass))
			return;
		isCellOpen = true;
		isMenuOpen = true;//Somente para desabilitar o menu de abrir
		GameStateManager.Instance.SetState(GameState.Phone);
		cellphonePanel.SetActive(isCellOpen);
	}

	public void CloseCellphone() {
		isCellOpen = false;
		isMenuOpen = false; //Somente para desabilitar o menu de abrir
		GameStateManager.Instance.SetState(GameState.Class);
		cellphonePanel.SetActive(isCellOpen);
	}

	public bool GetMenuStatus(){
		return isMenuOpen;
	}

	public bool OpenMenu(){
		if(isCellOpen == true){
			return true;
		}
        isMenuOpen = false;
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

