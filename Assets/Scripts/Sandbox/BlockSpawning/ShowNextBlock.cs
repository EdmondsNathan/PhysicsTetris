using UnityEngine;

public class ShowNextBlock : MonoBehaviour
{
	private GameObject _nextBlock;

	protected void OnEnable()
	{
		Message_SpawnBlock.NextBlock += ShowBlock;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.NextBlock -= ShowBlock;
	}

	private void ShowBlock(GameObject block)
	{
		if (_nextBlock != null)
		{
			Destroy(_nextBlock);
		}

		_nextBlock = Instantiate(block, transform.position, block.transform.rotation);
	}
}
