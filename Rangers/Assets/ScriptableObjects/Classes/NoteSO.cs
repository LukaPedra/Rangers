using UnityEngine;

[CreateAssetMenu(fileName = "Note", menuName = "Scriptable Objects/New note")]
public class NoteSO : ScriptableObject
{
	public string note_id;
	public string text_en;
	public string text_pt;
}

