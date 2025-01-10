using System.Collections.Generic;
using UnityEngine;

public class SelectBlockFromBag : MonoBehaviour, ISelectNextBlock
{
	[SerializeField] private BlockList _blockListObject;
	private List<GameObject> _blockPool;

	private int _index = 0;

	protected void Start()
	{
		_blockPool = new List<GameObject>(_blockListObject.Blocks);
	}

	public GameObject SelectNextBlock()
	{
		GameObject nextBlock = _blockPool[_index];

		_index = (_index + 1) % _blockPool.Count;

		if (_index == 0)
		{
			_blockPool.Shuffle();
		}

		return nextBlock;
	}
}
