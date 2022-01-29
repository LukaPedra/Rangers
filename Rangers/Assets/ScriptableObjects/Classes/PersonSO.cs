using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Person", menuName = "Scriptable Objects/New Person")]
public class PersonSO : ScriptableObject
{
	public string pid;
	public string pname;
	public uint age;
	public string description;
	public Image picture;
}

