using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
	[SerializeReference] private BlockSelector _nextBlockSelector;

	private GameObject _currentBlock, _nextBlock;

	public void SpawnNewBlock()
	{
		if (_nextBlock == null)
		{
			SetNextBlock();
		}

		SpawnNewBlock(_nextBlock);

		SetNextBlock();
	}

	public void SpawnNewBlock(GameObject block)
	{
		_currentBlock = Instantiate(block, transform.position, block.transform.rotation, transform);

		Message_SpawnBlock.NewBlockSpawned?.Invoke(_currentBlock);
	}

	private void SetNextBlock()
	{
		_nextBlock = _nextBlockSelector.SelectNextBlock();
		Message_SpawnBlock.NextBlock?.Invoke(_nextBlock);
	}

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

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Message_SpawnBlock.SpawnNextBlock?.Invoke();
		}
	}
}
