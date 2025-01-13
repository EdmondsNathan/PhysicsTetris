using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
	public static SpawnBlock BlockSpawner;
	[SerializeReference] private BlockSelector _nextBlockSelector;

	private GameObject _currentBlock;
	public void SpawnNewBlock()
	{
		SpawnNewBlock(_nextBlockSelector.SelectNextBlock());
	}

	public void SpawnNewBlock(GameObject block)
	{
		_currentBlock = Instantiate(block, transform.position, block.transform.rotation, transform);

		Message_NewBlockSpawned.NewBlockSpawned?.Invoke(_currentBlock);
	}

	protected void Awake()
	{
		if (BlockSpawner == null)
		{
			BlockSpawner = this;
		}
	}

	protected void OnEnable()
	{
		Message_SpawnNextBlock.SpawnNextBlock += SpawnNewBlock;
		Message_SpawnNextBlock.SpawnSpecificBlock += SpawnNewBlock;
	}

	protected void OnDisable()
	{
		Message_SpawnNextBlock.SpawnNextBlock -= SpawnNewBlock;
		Message_SpawnNextBlock.SpawnSpecificBlock -= SpawnNewBlock;
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Message_SpawnNextBlock.SpawnNextBlock?.Invoke();
		}
	}
}
