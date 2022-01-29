using UnityEngine;

public class NoteController : MonoBehaviour
{
	[SerializeField] private NoteSO[] notes;

	private bool[] isNoteUnlocked;
	private uint unlockedNotesNum;

	private void Awake() {
		isNoteUnlocked = new bool[notes.Length];
	}

	public NoteSO[] GetUnlockedNotes() {
		if (unlockedNotesNum == 0)
			return null;

		uint count = 0;
		NoteSO[] unlockedNotes = new NoteSO[unlockedNotesNum];

		for (uint i = 0; i < notes.Length; ++i) {
			if (isNoteUnlocked[i])
				unlockedNotes[count++] = notes[i];
		}

		return unlockedNotes;
	}

	public void UnlockNote(uint idx) {
		if (idx >= notes.Length) {
			Debug.Log("Invalid note index.", this);
			return;
		}

		if (!isNoteUnlocked[idx]) {
			unlockedNotesNum++;
			isNoteUnlocked[idx] = true;
		}
	}

	public void UnmeetPerson(uint idx) {
		if (idx >= notes.Length) {
			Debug.Log("Invalid note index.", this);
			return;
		}

		if (isNoteUnlocked[idx]) {
			unlockedNotesNum--;
			isNoteUnlocked[idx] = false;
		}
	}

}

