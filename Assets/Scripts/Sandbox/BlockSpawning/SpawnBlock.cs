using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
	[SerializeReference] private MonoBehaviour _nextBlockSelector;

	private ISelectNextBlock _nextBlockInterface;

	private GameObject _currentBlock;
	public void SpawnNewBlock()
	{
		if (_nextBlockInterface == null)
		{
			return;
		}

		_currentBlock = Instantiate(_nextBlockInterface.SelectNextBlock(), transform.position, transform.rotation, transform);

		Message_SpawnBlock.NewBlockSpawned?.Invoke(_currentBlock);
	}

	protected void OnEnable()
	{
		if (_nextBlockSelector is ISelectNextBlock)
		{
			_nextBlockInterface = (ISelectNextBlock)_nextBlockSelector;
		}
		else
		{
			_nextBlockInterface = GetComponent<ISelectNextBlock>();
		}

		if (_nextBlockInterface == null)
		{
			Debug.Log("Improperly assigned ISelectNextBlock interface");
		}
	}

	protected void Start()
	{
		SpawnNewBlock();
	}

	protected void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnNewBlock();
		}
	}
}
