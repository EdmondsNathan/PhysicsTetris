using System.Collections.Generic;
using UnityEngine;

public class SelectRandomBlock : BlockSelector
{
	public override GameObject SelectNextBlock()
	{
		return _blockPool[Random.Range(0, _blockPool.Count)];
	}
}
