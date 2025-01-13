using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
	[SerializeReference] private BlockSelector _nextBlockSelector;

	private GameObject _currentBlock, _nextBlock;

	protected void OnEnable()
	{
		Message_SpawnBlock.SpawnNextBlock += SpawnNewBlock;
		Message_SpawnBlock.SpawnSpecificBlock += SpawnNewBlock;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.SpawnNextBlock -= SpawnNewBlock;
		Message_SpawnBlock.SpawnSpecificBlock -= SpawnNewBlock;
	}

	private void SpawnNewBlock()
	{
		if (_nextBlock == null)
		{
			SetNextBlock();
		}

		SpawnNewBlock(_nextBlock);

		SetNextBlock();
	}

	private void SpawnNewBlock(GameObject block)
	{
		Message_SpawnBlock.BeforeBlockSpawn?.Invoke();

		_currentBlock = Instantiate(block, transform.position, block.transform.rotation, transform);

		Message_SpawnBlock.NewBlockSpawned?.Invoke(_currentBlock);
	}

	private void SetNextBlock()
	{
		_nextBlock = _nextBlockSelector.SelectNextBlock();
		Message_SpawnBlock.NextBlock?.Invoke(_nextBlock);
	}
}
