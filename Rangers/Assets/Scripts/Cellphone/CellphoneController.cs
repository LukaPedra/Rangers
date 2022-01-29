using UnityEngine;

public class CellphoneController : MonoBehaviour
{
	[SerializeField] private GameObject launcherScreen;
	[SerializeField] private GameObject notepadScreen;
	[SerializeField] private GameObject contactsScreen;
	[SerializeField] private GameManager gameManager;

	private enum CellphoneState {Launcher, Notepad, Contacts};
	private CellphoneState cellphoneState;

	private void Start() {
		cellphoneState = CellphoneState.Launcher;

		// launcherScreen.SetActive(false);
		notepadScreen.SetActive(false);
		contactsScreen.SetActive(false);
	}

	public void GoBack() {
		switch (cellphoneState) {
			case CellphoneState.Launcher:
				gameManager.CloseCellphone();
				break;

			case CellphoneState.Notepad:
				notepadScreen.SetActive(false);
				launcherScreen.SetActive(true);
				cellphoneState = CellphoneState.Launcher;
				break;

			case CellphoneState.Contacts:
				contactsScreen.SetActive(false);
				launcherScreen.SetActive(true);
				cellphoneState = CellphoneState.Launcher;
				break;
		}
	}

	public void OpenNotepad() {
		if (cellphoneState != CellphoneState.Launcher)
			return;

		cellphoneState = CellphoneState.Notepad;
		launcherScreen.SetActive(false);
		notepadScreen.SetActive(true);
	}

	public void OpenContacts() {
		if (cellphoneState != CellphoneState.Launcher)
			return;

		cellphoneState = CellphoneState.Contacts;
		launcherScreen.SetActive(false);
		contactsScreen.SetActive(true);
	}

}
