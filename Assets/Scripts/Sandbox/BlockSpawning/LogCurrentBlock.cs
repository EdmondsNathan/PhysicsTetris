using UnityEngine;

public class LogCurrentBlock : MonoBehaviour
{
	protected void OnEnable()
	{
		Message_NewBlockSpawned.NewBlockSpawned += LogNewBlock;
	}

	protected void OnDisable()
	{
		Message_NewBlockSpawned.NewBlockSpawned -= LogNewBlock;
	}

	public void LogNewBlock(GameObject block)
	{
		Debug.Log(block.name);
	}
}
