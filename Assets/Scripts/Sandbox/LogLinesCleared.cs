using UnityEditor.VersionControl;
using UnityEngine;

public class LogLinesCleared : MonoBehaviour
{
	protected void OnEnable()
	{
		Message_LinesCleared.LinesCleared += LogLines;
	}

	protected void OnDisable()
	{
		Message_LinesCleared.LinesCleared -= LogLines;
	}

	public void LogLines(int linesCleared)
	{
		if (linesCleared == 4)
		{
			Debug.Log("TETRIS!");
			return;
		}

		Debug.Log(linesCleared + " lines cleared");
	}
}
