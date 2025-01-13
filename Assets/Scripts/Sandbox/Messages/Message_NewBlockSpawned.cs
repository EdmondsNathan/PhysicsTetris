using UnityEngine;

public static class Message_NewBlockSpawned
{
	public delegate void _newBlockSpawned(GameObject block);
	public static _newBlockSpawned NewBlockSpawned;
}
