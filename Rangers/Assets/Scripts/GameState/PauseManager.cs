using UnityEngine;

public class PauseManager : MonoBehaviour
{

	public void Pause() {
		GameState currentGameState = GameStateManager.Instance.CurrentGameState;
		if (currentGameState == GameState.Class)
			GameStateManager.Instance.SetState(GameState.Paused);
	}

	public void Unpause() {
		GameState currentGameState = GameStateManager.Instance.CurrentGameState;
		if (currentGameState == GameState.Class)
			GameStateManager.Instance.SetState(GameState.Paused);
	}

	public void TogglePause() {
		GameState currentGameState = GameStateManager.Instance.CurrentGameState;
		if (currentGameState == GameState.Paused)
			GameStateManager.Instance.SetState(GameState.Class);
		else if (currentGameState == GameState.Paused)
			GameStateManager.Instance.SetState(GameState.Paused);
	}
}

