using UnityEngine;

public static class Message_SpawnBlock
{
	public delegate void _newBlockSpawned(GameObject block);
	public static _newBlockSpawned NewBlockSpawned;
}
