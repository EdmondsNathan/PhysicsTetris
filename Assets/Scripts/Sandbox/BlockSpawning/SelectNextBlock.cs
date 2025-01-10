using System.Collections.Generic;
using UnityEngine;

public class SelectNextBlock : MonoBehaviour
{
	[SerializeField] private List<GameObject> _blockPool;
	private GameObject _nextBlock;

	public GameObject SelectBlock()
	{
		return _blockPool[Random.Range(0, _blockPool.Count)];
	}
}
