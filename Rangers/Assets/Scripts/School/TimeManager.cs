using UnityEngine;

public class TimeManager : MonoBehaviour
{
	[SerializeField] private static double stdTimeScale = 20.0; /* how many ig secs mean irl secs */

	private double timeScale = stdTimeScale;

	public static TimeManager Instance { get; private set; }

	private double ingameTime = 60.0 * 60.0 * SchoolClasses.SchoolStartTime;
	private double deltaTime = 0.0f;
	private int lastHour = 0;

	public double IngameTime { get => ingameTime; }
	public int IngameSecs { get => (int)(ingameTime % 60.0); }
	public int IngameMins { get => (int)(ingameTime / 60.0 % 60.0); }
	public int IngameHour { get => (int)(ingameTime / 3600.0); }

	public delegate void GameHour(int hour);
	public event GameHour OnGameHourEllapsed;

	private TimeManager() { }

	private void Awake() {
		if (Instance != null && Instance != this) {
			Destroy(this);
			throw new System.Exception("Singleton already exists");
		}
		Instance = this;
	}

	private void Update() {
		if (GameStateManager.Instance.CurrentGameState != GameState.Class)
			return;

		if ((deltaTime += Time.deltaTime) >= 1.0f) {
			deltaTime = 0.0f;
			ingameTime += timeScale;

			int currentHour = IngameHour;
			if (currentHour != lastHour) {
				OnGameHourEllapsed?.Invoke(currentHour);
				lastHour = currentHour;
			}
		}
	}

	public void setTimeScale(double newTimeScale) => timeScale = newTimeScale;
	public void defaultTimeScale() => timeScale = stdTimeScale;

	public void Sleep() {
		if (IngameTime<32400f) {
			SetTime(8,58);
		} else if ((32400f<=IngameTime)&&(IngameTime<39600f)) {
			SetTime(10,58);
		} else if ((39600f<=IngameTime)&&(IngameTime<46800f)) {
			SetTime(12,58);
		} else if((46800f<=IngameTime)&&(IngameTime<54000f)) {
			SetTime(14,58);
		} else if((54000f<=IngameTime)&&(IngameTime<61200f)) {
			SetTime(16,58);
		}

	}

	public void SetTime(int hour, int min) {
		ingameTime = hour * 3600.0 + min * 60.0;
		int currentHour = IngameHour;
		if (currentHour != lastHour) {
			OnGameHourEllapsed?.Invoke(currentHour);
			lastHour = currentHour;
		}
	}

	public void SetHour(int hour) {
		ingameTime = hour * 3600.0;
		int currentHour = IngameHour;
		if (currentHour != lastHour) {
			OnGameHourEllapsed?.Invoke(currentHour);
			lastHour = currentHour;
		}
	}

	public void SetMin(int min) {
		int currentHour = IngameHour;
		ingameTime = currentHour + min * 60.0;
		if (currentHour != lastHour) {
			OnGameHourEllapsed?.Invoke(currentHour);
			lastHour = currentHour;
		}
	}

}

