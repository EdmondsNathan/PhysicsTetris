using System;
using UnityEngine;

public static class Message_SpawnBlock
{
	public static Action SpawnNextBlock;

	public static Action<GameObject> SpawnSpecificBlock;

	public static Action<GameObject> NewBlockSpawned;

	public static Action<GameObject> NextBlock;
}
