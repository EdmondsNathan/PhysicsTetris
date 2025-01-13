using UnityEngine;

public static class PauseGame
{
	private static bool _isPaused = false;

	public static void TogglePause()
	{
		_isPaused = !_isPaused;

		Message_PauseGame.PauseGame?.Invoke(_isPaused);
	}

	public static void LogPauseState(bool isPaused)
	{
		Debug.Log(isPaused);
	}
}
