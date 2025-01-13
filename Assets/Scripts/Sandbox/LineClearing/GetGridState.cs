using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetGridState : MonoBehaviour
{
	[SerializeField] private Transform _blockSpawner;

	[SerializeField] private int _boardWidth, _boardHeight;

	private Dictionary<Vector2Int, GameObject> _gridDictionary;

	protected void OnEnable()
	{
		Message_SpawnBlock.BeforeBlockSpawn += RefreshGridDictionary;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.BeforeBlockSpawn -= RefreshGridDictionary;
	}

	public void RefreshGridDictionary()
	{
		_gridDictionary = new Dictionary<Vector2Int, GameObject>();

		Vector2Int currentBlockLocation;

		foreach (GetBlockLocation blockLocation in _blockSpawner.GetComponentsInChildren<GetBlockLocation>())
		{
			currentBlockLocation = blockLocation.GetLocation();

			if (currentBlockLocation.y > _boardHeight)
			{
				//MESSAGE GAME OVER
				Debug.Log("Game Over");
			}

			if (_gridDictionary.ContainsKey(currentBlockLocation) == false)
			{
				_gridDictionary[currentBlockLocation] = blockLocation.gameObject;
			}
			else if (Vector2.Distance(currentBlockLocation, blockLocation.transform.position) <
			Vector2.Distance(currentBlockLocation, _gridDictionary[currentBlockLocation].transform.position))
			{
				_gridDictionary[currentBlockLocation] = blockLocation.gameObject;
			}
		}

		RemoveCompletedRows();
	}

	private void RemoveCompletedRows()
	{
		int linesCleared = 0;

		Vector2Int currentLocation = new Vector2Int();

		for (int y = 0; y < _boardHeight; y++)
		{
			bool fullRow = true;

			currentLocation.y = y;

			for (int x = 0; x < _boardWidth; x++)
			{
				currentLocation.x = x;

				if (_gridDictionary.ContainsKey(currentLocation) == false)
				{
					fullRow = false;
				}
			}

			if (fullRow)
			{
				linesCleared++;

				for (int x = 0; x < _boardWidth; x++)
				{
					currentLocation.x = x;
					Destroy(_gridDictionary[currentLocation]);

					Transform owner = _gridDictionary[currentLocation].transform.parent;

					if (owner != transform)
					{
						for (int i = owner.childCount - 1; i >= 0; i--)
						{
							owner.GetChild(i).AddComponent<Rigidbody2D>();
							owner.GetChild(i).parent = owner.parent;
						}
						Destroy(owner.gameObject);
					}

					_gridDictionary.Remove(currentLocation);
				}
			}
		}

		if (linesCleared > 0)
		{
			Message_LinesCleared.LinesCleared?.Invoke(linesCleared);
		}
	}
}
