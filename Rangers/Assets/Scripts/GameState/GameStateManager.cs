/*
 * credits to: https://gist.github.com/JamesPreston1993/a787979d925fc17ee4406ec5d172764f
 */

public class GameStateManager
{
	private static GameStateManager instance = null;
	public static GameStateManager Instance {
		get {
			if (instance == null)
				instance = new GameStateManager();

			return instance;
		}
	}

	public GameState CurrentGameState { get; private set; }

	public delegate void GameStateChangeHandler(GameState newGameState);
	public event GameStateChangeHandler OnGameStateChanged;

	private GameStateManager() { }

	public void SetState(GameState newGameState) {
		if (newGameState == CurrentGameState)
			return;

		CurrentGameState = newGameState;
		OnGameStateChanged?.Invoke(newGameState);
	}
}

