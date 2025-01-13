using System;
using TMPro;
using UnityEngine;

public class ShowNextBlockTimer : MonoBehaviour
{
	protected void OnEnable()
	{
		Message_SpawnBlock.NextBlockTimer += DisplayTimer;
	}

	protected void OnDisable()
	{
		Message_SpawnBlock.NextBlockTimer -= DisplayTimer;
	}

	public void DisplayTimer(float timer)
	{
		GetComponent<TMP_Text>().text = Math.Ceiling(timer).ToString();
	}
}
