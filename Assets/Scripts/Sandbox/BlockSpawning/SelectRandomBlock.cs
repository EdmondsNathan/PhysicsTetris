using System.Collections.Generic;
using UnityEngine;

public class SelectRandomBlock : MonoBehaviour, ISelectNextBlock
{
	[SerializeField] private BlockList _blockListObject;
	private List<GameObject> _blockPool;

	protected void Start()
	{
		_blockPool = new List<GameObject>(_blockListObject.Blocks);
	}

	public GameObject SelectNextBlock()
	{
		return _blockPool[Random.Range(0, _blockPool.Count)];
	}
}
