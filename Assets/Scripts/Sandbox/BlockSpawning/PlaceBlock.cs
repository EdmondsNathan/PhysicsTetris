using UnityEngine;
using UnityEngine.InputSystem;

public class PlaceBlock : MonoBehaviour
{
	[SerializeField] private float _minDelay = 1f;

	private float _currentTimer = 0f;

	protected void OnEnable()
	{
		Message_SpawnBlock.NewBlockSpawned += ResetTimer;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.NewBlockSpawned -= ResetTimer;
	}

	protected void Update()
	{
		if (_currentTimer <= 0)
		{
			return;
		}

		_currentTimer -= Time.deltaTime;
	}

	public void OnPlace(InputValue inputValue)
	{
		if (_currentTimer > 0)
		{
			return;
		}

		Message_SpawnBlock.SpawnNextBlock?.Invoke();
	}

	public void ResetTimer(GameObject block)
	{
		_currentTimer = _minDelay;
	}
}
