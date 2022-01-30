using UnityEngine;

public class SchoolClassManager : MonoBehaviour
{
	public static SchoolClassManager Instance { get; private set; }

	private SchoolClass currentClass;

	public SchoolClass CurrentClass { get => currentClass; }

	private SchoolClassManager() { }

	private void Awake() {
		if (Instance != null && Instance != this) {
			Destroy(this);
			throw new System.Exception("Singleton already exists");
		}
		Instance = this;
	}

	private void Start() {
		TimeManager.Instance.OnGameHourEllapsed += OnGameHourEllapsed;
		currentClass = SchoolClasses.GetCurrentClass(TimeManager.Instance.IngameHour);
	}

	private void OnDestroy() {
		TimeManager.Instance.OnGameHourEllapsed -= OnGameHourEllapsed;
	}

	private void OnGameHourEllapsed(int currentHour) {
		currentClass = SchoolClasses.GetCurrentClass(currentHour);
	}
}

