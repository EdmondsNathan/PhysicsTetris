using UnityEngine;

public class SpawnBlockOnStart : MonoBehaviour
{
	protected void Start()
	{
		Message_SpawnBlock.SpawnNextBlock?.Invoke();
	}
}
