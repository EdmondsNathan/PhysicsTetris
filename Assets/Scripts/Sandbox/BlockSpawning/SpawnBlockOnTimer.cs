using UnityEngine;

public class SpawnBlockOnTimer : MonoBehaviour
{
	[SerializeField] private float _delay;

	private float _currentTimer = 0;

	protected void OnEnable()
	{
		Message_SpawnBlock.NewBlockSpawned += StartTimer;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.NewBlockSpawned -= StartTimer;
	}

	protected void Update()
	{
		if (_currentTimer <= 0)
		{
			return;
		}

		_currentTimer -= Time.deltaTime;

		if (_currentTimer <= 0)
		{
			Message_SpawnBlock.SpawnNextBlock?.Invoke();

			_currentTimer = 0;
		}

		Message_SpawnBlock.NextBlockTimer?.Invoke(_currentTimer);
	}

	public void StartTimer(GameObject block)
	{
		_currentTimer = _delay;
	}
}
