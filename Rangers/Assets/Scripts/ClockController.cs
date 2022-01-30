using System;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI clockText;

	private TimeManager timeManager;

	private void Start() {
		timeManager = TimeManager.Instance;
	}

	private void Update() {
		clockText.text = String.Format("{0:00}:{1:00}", timeManager.IngameHour, timeManager.IngameMins);
	}
}
