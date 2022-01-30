using UnityEngine;

public class TimeManager : MonoBehaviour
{
	[SerializeField] private float timeScale = 20.0f; /* how many ig secs mean irl secs */
	private float copytimescale;

	public static TimeManager Instance { get; private set; }

	private float ingameTime = 60.0f * 60.0f * SchoolClasses.SchoolStartTime;
	private float deltaTime = 0.0f;
	private int lastHour = 0;

	public float IngameTime { get => ingameTime; }
	public int IngameSecs { get => Mathf.FloorToInt(ingameTime % 60.0f); }
	public int IngameMins { get => Mathf.FloorToInt(ingameTime / 60.0f % 60.0f); }
	public int IngameHour { get => Mathf.FloorToInt(ingameTime / 3600.0f); }

	public delegate void GameHour(int hour);
	public event GameHour OnGameHourEllapsed;

	private TimeManager() { }

	private void Awake() {
		if (Instance != null && Instance != this) {
			Destroy(this);
			throw new System.Exception("Singleton already exists");
		}
		copytimescale = timeScale;
		Instance = this;
	}

	private void Update() {
		if (GameStateManager.Instance.CurrentGameState != GameState.Class)
			return;

		if ((deltaTime += Time.deltaTime) >= 1.0f) {
			deltaTime = 0;
			ingameTime += timeScale;

			int currentHour = IngameHour;
			if (currentHour != lastHour) {
				OnGameHourEllapsed?.Invoke(currentHour);
				lastHour = currentHour;
			}
		}
	}
	public void setTimeScale(float n){
		timeScale = n;
	}
	public void defaultTimeScale(){
		timeScale = copytimescale;
	}
	 public void Sleep(){
        Debug.Log("cima");
        if(IngameTime<32400f){
            Debug.Log("baixo");
            SetTime(8,58);
        }
        else if((32400f<=IngameTime)&&(IngameTime<39600f)){
            SetTime(10,58);
        }
        else if((39600f<=IngameTime)&&(IngameTime<46800f)){
            SetTime(12,58);
        }
        else if((46800f<=IngameTime)&&(IngameTime<54000f)){
            SetTime(14,58);
        }
        else if((54000f<=IngameTime)&&(IngameTime<61200f)){
            SetTime(16,58);
        }
        
    }

	public void SetTime(int hour, int min) {
		ingameTime = hour * 3600.0f + min * 60.0f;
		int currentHour = IngameHour;
		if (currentHour != lastHour) {
			OnGameHourEllapsed?.Invoke(currentHour);
			lastHour = currentHour;
		}
	}

	public void SetHour(int hour) {
		ingameTime = hour * 3600.0f;
		int currentHour = IngameHour;
		if (currentHour != lastHour) {
			OnGameHourEllapsed?.Invoke(currentHour);
			lastHour = currentHour;
		}
	}

	public void SetMin(int min) {
		int currentHour = IngameHour;
		ingameTime = currentHour + min * 60.0f;
		if (currentHour != lastHour) {
			OnGameHourEllapsed?.Invoke(currentHour);
			lastHour = currentHour;
		}
	}

}

