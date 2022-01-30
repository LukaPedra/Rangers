using System.Collections;
using UnityEngine;

public class ContactsAppController : MonoBehaviour
{
	[SerializeField] private GameObject contactPrefab;
	[SerializeField] private GameObject contactsPanel;

	private Hashtable contactsTable = new Hashtable();

	public void AddContact(PersonSO person) {
		GameObject contact = Instantiate(contactPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		contact.transform.parent = contactsPanel.transform;
		contact.GetComponent<ContactBehaviour>().ContactID = person.pid;
		contactsTable.Add(person.pid, contact);
	}

	public void RemoveContact(string pid) => contactsTable.Remove(name);

}

