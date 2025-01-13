using UnityEngine;
using UnityEngine.InputSystem;

public class HoldBlock : MonoBehaviour
{
	[SerializeField] private Transform _holdLocation;
	private GameObject _heldBlock = null;

	private GameObject _currentBlock;

	private bool _lockedOut = true;

	protected void OnEnable()
	{
		Message_NewBlockSpawned.NewBlockSpawned += SetCurrentBlock;
	}

	protected void OnDisable()
	{
		Message_NewBlockSpawned.NewBlockSpawned -= SetCurrentBlock;
	}

	public void SetCurrentBlock(GameObject block)
	{
		_currentBlock = block;

		_lockedOut = false;
	}

	public void OnHold(InputValue inputValue)
	{
		if (_lockedOut == true)
		{
			return;
		}

		GameObject oldBlock = _currentBlock;

		// _currentBlock.transform.position = new Vector2(100, 100);


		//_currentBlock.GetComponent<Rigidbody2D>().position = _holdLocation.position;

		_currentBlock.transform.position = _holdLocation.position;

		_currentBlock.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

		_currentBlock.GetComponent<Rigidbody2D>().angularVelocity = 0;

		_currentBlock.transform.parent = null;

		if (_heldBlock == null)
		{
			_heldBlock = _currentBlock;

			Message_SpawnNextBlock.SpawnNextBlock?.Invoke();
		}
		else
		{
			//_heldBlock.SetActive(true);

			GameObject oldHeldBlock = _heldBlock;

			Message_SpawnNextBlock.SpawnSpecificBlock?.Invoke(_heldBlock);

			_heldBlock = oldBlock;

			Destroy(oldHeldBlock);
		}



		//_heldBlock.SetActive(false);

		_lockedOut = true;
	}
}
