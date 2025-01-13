using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseInput : MonoBehaviour
{
	public void OnPause(InputValue inputValue)
	{
		PauseGame.TogglePause();
	}

	protected void Start()
	{
		Message_PauseGame.PauseGame += PauseGame.LogPauseState;
	}
}
