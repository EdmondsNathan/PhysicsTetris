using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BlockList")]
public class BlockList : ScriptableObject
{
	public List<GameObject> Blocks;
}
