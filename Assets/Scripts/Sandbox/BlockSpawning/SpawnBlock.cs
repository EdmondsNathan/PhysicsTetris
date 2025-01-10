using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
	private GameObject _currentBlock;
	public void SpawnNewBlock(GameObject block)
	{
		_currentBlock = Instantiate(block, transform.position, transform.rotation, transform);

		Message_SpawnBlock.NewBlockSpawned?.Invoke(_currentBlock);
	}

	protected void Start()
	{
		SpawnNewBlock(GetComponent<SelectNextBlock>().SelectBlock());
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnNewBlock(GetComponent<SelectNextBlock>().SelectBlock());
		}
	}
}
