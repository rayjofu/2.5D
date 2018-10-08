using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public InputController input;

	private void OnEnable()
	{
		input.On_A_Down += Jump;
	}

	private void OnDisable()
	{
		input.On_A_Down -= Jump;
	}

	private void Jump()
	{
		
	}
}
