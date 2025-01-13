using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
	[SerializeReference] private BlockSelector _nextBlockSelector;

	private GameObject _currentBlock, _nextBlock;

	// private bool _isSpawnReady = true;

	protected void OnEnable()
	{
		Message_SpawnBlock.SpawnNextBlock += SpawnNewBlock;
		Message_SpawnBlock.SpawnSpecificBlock += SpawnNewBlock;
		// Message_SpawnBlock.SpawnIsReady += ReadySpawn;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.SpawnNextBlock -= SpawnNewBlock;
		Message_SpawnBlock.SpawnSpecificBlock -= SpawnNewBlock;
		// Message_SpawnBlock.SpawnIsReady -= ReadySpawn;
	}

	private void SpawnNewBlock()
	{
		// if (_isSpawnReady == false)
		// {
		// 	return;
		// }

		if (_nextBlock == null)
		{
			SetNextBlock();
		}

		SpawnNewBlock(_nextBlock);

		SetNextBlock();
	}

	private void SpawnNewBlock(GameObject block)
	{
		// if (_isSpawnReady == false)
		// {
		// 	return;
		// }

		_currentBlock = Instantiate(block, transform.position, block.transform.rotation, transform);

		Message_SpawnBlock.NewBlockSpawned?.Invoke(_currentBlock);
	}

	private void SetNextBlock()
	{
		_nextBlock = _nextBlockSelector.SelectNextBlock();
		Message_SpawnBlock.NextBlock?.Invoke(_nextBlock);
	}

	// private void ReadySpawn(bool isReady)
	// {
	// 	_isSpawnReady = isReady;
	// }
}
