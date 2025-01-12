using Unity.Mathematics;
using UnityEngine;

public class GetBlockLocation : MonoBehaviour
{
	public Vector2Int GetLocation()
	{
		return new Vector2Int((int)math.round(transform.position.x), (int)math.round(transform.position.y));
	}
}
