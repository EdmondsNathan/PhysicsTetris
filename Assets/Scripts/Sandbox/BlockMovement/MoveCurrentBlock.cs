using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCurrentBlock : MonoBehaviour
{
	//private GameObject _currentBlock;

	private Vector2 _movementVector;

	private float _rotation;

	private Rigidbody2D _currentRigidbody;

	[SerializeField] private float _moveSpeed, _turnSpeed;

	[SerializeField] private float _upSpeed, _downSpeed;

	protected void OnEnable()
	{
		Message_NewBlockSpawned.NewBlockSpawned += UpdateCurrentBlock;
	}

	protected void OnDisable()
	{
		Message_NewBlockSpawned.NewBlockSpawned -= UpdateCurrentBlock;
	}

	protected void Start()
	{

	}

	public void UpdateCurrentBlock(GameObject block)
	{
		//_currentBlock = block;
		_currentRigidbody = block.GetComponent<Rigidbody2D>();
	}

	protected void FixedUpdate()
	{
		if (_currentRigidbody == null)
		{
			return;
		}

		_currentRigidbody.AddForce(Vector2.right * _movementVector * _moveSpeed);

		if (_movementVector.y < 0)
		{
			_currentRigidbody.AddForce(Vector2.up * _movementVector.y * _downSpeed);
		}

		_currentRigidbody.AddTorque(_rotation * _turnSpeed);
	}

	public void OnMove(InputValue inputValue)
	{
		_movementVector = inputValue.Get<Vector2>();
	}

	public void OnRotate(InputValue inputValue)
	{
		_rotation = inputValue.Get<float>();
	}
}
