using Unity.Mathematics;
using UnityEngine;

public class GetBlockLocation : MonoBehaviour
{
	public Vector2Int GetLocation()
	{
		return new Vector2Int((int)math.floor(transform.position.x), (int)math.floor(transform.position.y));
	}
}
