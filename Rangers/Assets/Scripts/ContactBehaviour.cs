using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class ContactBehaviour : MonoBehaviour
{
	[SerializeField] private LocalizeStringEvent contactName;
	[SerializeField] private LocalizeStringEvent contactDescription;

	private string contactID;

	public string ContactID {
		get => contactID;

		set {
			contactID = value;

			LocalizedString contactNameLS = new LocalizedString();
			contactNameLS.TableReference = "CharacterNames";
			contactNameLS.TableEntryReference = contactID;
			contactName.StringReference = contactNameLS;

			LocalizedString contactDescriptionLS = new LocalizedString();
			contactDescriptionLS.TableReference = "CharacterDescriptions";
			contactDescriptionLS.TableEntryReference = contactID;
			contactDescription.StringReference = contactDescriptionLS;
		}
	}
}

