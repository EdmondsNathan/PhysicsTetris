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
		Message_SpawnBlock.NewBlockSpawned += SetCurrentBlock;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.NewBlockSpawned -= SetCurrentBlock;
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

		#region Move block to holding
		_currentBlock.transform.position = _holdLocation.position;

		_currentBlock.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

		_currentBlock.GetComponent<Rigidbody2D>().angularVelocity = 0;

		_currentBlock.transform.parent = null;
		#endregion

		#region Hold block and spawn next block
		if (_heldBlock == null)
		{
			_heldBlock = _currentBlock;

			Message_SpawnBlock.SpawnNextBlock?.Invoke();
		}
		else
		{
			GameObject oldHeldBlock = _heldBlock;

			Message_SpawnBlock.SpawnSpecificBlock?.Invoke(_heldBlock);

			_heldBlock = oldBlock;

			Destroy(oldHeldBlock);
		}

		_lockedOut = true;
		#endregion
	}
}
