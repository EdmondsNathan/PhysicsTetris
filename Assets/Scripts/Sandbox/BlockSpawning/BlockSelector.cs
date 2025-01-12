using System.Collections.Generic;
using UnityEngine;

public abstract class BlockSelector : MonoBehaviour, ISelectNextBlock
{
	[SerializeField] private BlockList _blockListObject;
	protected List<GameObject> _blockPool;

	protected virtual void Awake()
	{
		_blockPool = new List<GameObject>(_blockListObject.Blocks);
	}

	public abstract GameObject SelectNextBlock();
}
