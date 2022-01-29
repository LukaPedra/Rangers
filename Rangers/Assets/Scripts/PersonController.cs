using UnityEngine;

public class PersonController : MonoBehaviour
{
	[SerializeField] private PersonSO[] persons;

	private bool[] isPersonKnown;
	private uint knownPersonsNum;

	public PersonSO GetPerson(uint idx) {
		if (idx > persons.Length)
			return null;

		return persons[idx];
	}

	public PersonSO[] GetKnownPersons() {
		if (knownPersonsNum == 0)
			return null;

		uint count = 0;
		PersonSO[] knownPersons = new PersonSO[knownPersonsNum];

		for (uint i = 0; i < persons.Length; ++i) {
			if (isPersonKnown[i])
				knownPersons[count++] = persons[i];
		}

		return knownPersons;
	}

	public void MeetPerson(uint idx) {
		if (idx >= persons.Length) {
			Debug.Log("Invalid person index.", this);
			return;
		}

		if (!isPersonKnown[idx]) {
			knownPersonsNum++;
			isPersonKnown[idx] = true;
		}
	}

	public void UnmeetPerson(uint idx) {
		if (idx >= persons.Length) {
			Debug.Log("Invalid person index.", this);
			return;
		}

		if (isPersonKnown[idx]) {
			knownPersonsNum--;
			isPersonKnown[idx] = false;
		}
	}

}

