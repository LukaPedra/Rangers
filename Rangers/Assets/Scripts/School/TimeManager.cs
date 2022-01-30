using UnityEngine;

public class TimeManager : MonoBehaviour
{
	[SerializeField] private float timeScale = 20.0f; /* how many ig secs mean irl secs */

	private float ingameTime = 0.0f;
	private float deltaTime = 0.0f;
	private int lastHour = 0;

	public float IngameTime { get => ingameTime; }
	public int IngameSecs { get => Mathf.FloorToInt(ingameTime % 60.0f); }
	public int IngameMins { get => Mathf.FloorToInt(ingameTime / 60.0f % 60.0f); }
	public int IngameHour { get => Mathf.FloorToInt(ingameTime / 3600.0f); }

	public delegate void GameHour(int hour);
	public event GameHour OnGameHourEllapsed;

	private void Update() {
		if (GameStateManager.Instance.CurrentGameState != GameState.Class)
			return;

		if ((deltaTime += Time.deltaTime) >= timeScale) {
			deltaTime = 0;
			ingameTime++;

			int currentHour = IngameHour;
			if (currentHour != lastHour) {
				OnGameHourEllapsed?.Invoke(currentHour);
				lastHour = currentHour;
			}
		}
	}
}

