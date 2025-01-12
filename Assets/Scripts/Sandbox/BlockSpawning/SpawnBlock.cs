using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
	[SerializeReference] private BlockSelector _nextBlockSelector;

	private GameObject _currentBlock;
	public void SpawnNewBlock()
	{
		_currentBlock = Instantiate(_nextBlockSelector.SelectNextBlock(), transform.position, transform.rotation, transform);

		Message_SpawnBlock.NewBlockSpawned?.Invoke(_currentBlock);
	}

	protected void Start()
	{
		SpawnNewBlock();
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnNewBlock();
		}
	}
}
