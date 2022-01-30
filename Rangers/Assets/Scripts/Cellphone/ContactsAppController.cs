using System.Collections;
using UnityEngine;

public class ContactsAppController : MonoBehaviour
{
	[SerializeField] private GameObject contactPrefab;
	[SerializeField] private GameObject contactsPanel;

	private Hashtable contactsTable = new Hashtable();

	public void AddContact(PersonSO person) {
		GameObject contact = Instantiate(contactPrefab, contactsPanel.transform);
		contact.GetComponent<ContactBehaviour>().ContactID = person.pid;
		contactsTable.Add(person.pid, contact);
	}

	public void RemoveContact(string pid) => contactsTable.Remove(name);

}

