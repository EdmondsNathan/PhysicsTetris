using System.Collections.Generic;
using UnityEngine;

public class SelectBlockFromBag : BlockSelector
{
	private int _index = 0;

	public override GameObject SelectNextBlock()
	{
		if (_index == 0)
		{
			_blockPool.Shuffle();
		}

		GameObject nextBlock = _blockPool[_index];

		_index = (_index + 1) % _blockPool.Count;

		return nextBlock;
	}
}
