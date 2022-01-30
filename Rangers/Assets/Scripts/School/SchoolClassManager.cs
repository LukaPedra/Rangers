using UnityEngine;

public class SchoolClassManager : MonoBehaviour
{
	private SchoolClass currentClass;

	public SchoolClass CurrentClass { get => currentClass; }

	private void Awake() {
		TimeManager.Instace.OnGameHourEllapsed += OnGameHourEllapsed;
	}

	private void OnDestroy() {
		TimeManager.Instace.OnGameHourEllapsed -= OnGameHourEllapsed;
	}

	private void Start() {
		currentClass = SchoolClasses.GetCurrentClass(TimeManager.Instace.IngameHour);
	}

	private void OnGameHourEllapsed(int currentHour) {
		currentClass = SchoolClasses.GetCurrentClass(currentHour);
	}
}

