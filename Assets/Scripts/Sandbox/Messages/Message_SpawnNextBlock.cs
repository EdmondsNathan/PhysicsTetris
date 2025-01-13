using UnityEngine;

public static class Message_SpawnNextBlock
{
	public delegate void _spawnNextBlock();
	public static _spawnNextBlock SpawnNextBlock;

	public delegate void _spawnSpecificBlock(GameObject block);
	public static _spawnSpecificBlock SpawnSpecificBlock;
}
