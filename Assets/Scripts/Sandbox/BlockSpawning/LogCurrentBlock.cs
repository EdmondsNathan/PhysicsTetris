using UnityEngine;

public class LogCurrentBlock : MonoBehaviour
{
	protected void OnEnable()
	{
		Message_SpawnBlock.NewBlockSpawned += LogNewBlock;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.NewBlockSpawned -= LogNewBlock;
	}

	public void LogNewBlock(GameObject block)
	{
		Debug.Log(block.name);
	}
}
