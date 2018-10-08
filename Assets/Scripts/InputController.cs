using System;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	#if UNITY_EDITOR
	public bool logButtonEvents;
	#endif

	public event Action On_A_Down;
	public event Action On_A_Up;
	public event Action On_B_Down;
	public event Action On_B_Up;
	public event Action On_X_Down;
	public event Action On_X_Up;
	public event Action On_Y_Down;
	public event Action On_Y_Up;
	public event Action On_Back_Down;
	public event Action On_Back_Up;
	public event Action On_Start_Down;
	public event Action On_Start_Up;
	public event Action On_L_Bumper_Down;
	public event Action On_L_Bumper_Up;
	public event Action On_R_Bumper_Down;
	public event Action On_R_Bumper_Up;
	public event Action On_L_Stick_Down;
	public event Action On_L_Stick_Up;
	public event Action On_R_Stick_Down;
	public event Action On_R_Stick_Up;
	public event Action On_Dpad_U_Down;
	public event Action On_Dpad_U_Up;
	public event Action On_Dpad_D_Down;
	public event Action On_Dpad_D_Up;
	public event Action On_Dpad_L_Down;
	public event Action On_Dpad_L_Up;
	public event Action On_Dpad_R_Down;
	public event Action On_Dpad_R_Up;

	public enum InputType {
		A_Down,
		A_Up,
		B_Down,
		B_Up,
		X_Down,
		X_Up,
		Y_Down,
		Y_Up,
		Back_Down,
		Back_Up,
		Start_Down,
		Start_Up,
		L_Bumper_Down,
		L_Bumper_Up,
		R_Bumper_Down,
		R_Bumper_Up,
		L_Stick_Down,
		L_Stick_Up,
		R_Stick_Down,
		R_Stick_Up,
	}
	private InputType[] inputTypes;

	public class InputData {
		public Action action;
		public string identifier;
	}

	public Dictionary<InputType, InputData> inputs;

	// Use this for initialization
	void Start () {
		inputTypes = (InputType[])Enum.GetValues(typeof(InputType));
		inputs = new Dictionary<InputType, InputData>()
		{
			{ InputType.A_Down, new InputData() { action = On_A_Down, identifier = "Xbox A"} },
			{ InputType.A_Up, new InputData() { action = On_A_Up, identifier = "Xbox A"} },
			{ InputType.B_Down, new InputData() { action = On_B_Down, identifier = "Xbox B"} },
			{ InputType.B_Up, new InputData() { action = On_B_Up, identifier = "Xbox B"} },
			{ InputType.X_Down, new InputData() { action = On_X_Down, identifier = "Xbox X"} },
			{ InputType.X_Up, new InputData() { action = On_X_Up, identifier = "Xbox X"} },
			{ InputType.Y_Down, new InputData() { action = On_Y_Down, identifier = "Xbox Y"} },
			{ InputType.Y_Up, new InputData() { action = On_Y_Up, identifier = "Xbox Y"} },
			{ InputType.L_Bumper_Down, new InputData() { action = On_L_Bumper_Down, identifier = "Xbox L. Bumper"} },
			{ InputType.L_Bumper_Up, new InputData() { action = On_L_Bumper_Up, identifier = "Xbox L. Bumper"} },
			{ InputType.R_Bumper_Down, new InputData() { action = On_R_Bumper_Down, identifier = "Xbox R. Bumper"} },
			{ InputType.R_Bumper_Up, new InputData() { action = On_R_Bumper_Up, identifier = "Xbox R. Bumper"} },
			{ InputType.L_Stick_Down, new InputData() { action = On_L_Stick_Down, identifier = "Xbox L. Joystick"} },
			{ InputType.L_Stick_Up, new InputData() { action = On_L_Stick_Up, identifier = "Xbox L. Joystick"} },
			{ InputType.R_Stick_Down, new InputData() { action = On_R_Stick_Down, identifier = "Xbox R. Joystick"} },
			{ InputType.R_Stick_Up, new InputData() { action = On_R_Stick_Up, identifier = "Xbox R. Joystick"} },
			{ InputType.Back_Down, new InputData() { action = On_Back_Down, identifier = "Xbox Back"} },
			{ InputType.Back_Up, new InputData() { action = On_Back_Up, identifier = "Xbox Back"} },
			{ InputType.Start_Down, new InputData() { action = On_Start_Down, identifier = "Xbox Start"} },
			{ InputType.Start_Up, new InputData() { action = On_Start_Up, identifier = "Xbox Start"} },
		};
	}
	
	// Update is called once per frame
	void Update () {
		// // joysticks
		// if (Input.GetAxis("Xbox L. Joystick Vertical") < -0.001f || 0.001f < Input.GetAxis("Xbox L. Joystick Vertical") || Input.GetAxis("Xbox L. Joystick Horizontal") < -0.001f || 0.001f < Input.GetAxis("Xbox L. Joystick Horizontal"))
		// {
		// 	if (debugJoysticks) Debug.LogError("xbox l. joystick (" + Input.GetAxis("Xbox L. Joystick Vertical") + ", " + Input.GetAxis("Xbox L. Joystick Horizontal"));
		// }
		// if (Input.GetAxis("Xbox R. Joystick Vertical") < -0.001f || 0.001f < Input.GetAxis("Xbox R. Joystick Vertical") || Input.GetAxis("Xbox R. Joystick Horizontal") < -0.001f || 0.001f < Input.GetAxis("Xbox R. Joystick Horizontal"))
		// {
		// 	if (debugJoysticks) Debug.LogError("xbox r. joystick vertical " + Input.GetAxis("Xbox R. Joystick Vertical") + ", " + Input.GetAxis("Xbox R. Joystick Horizontal"));
		// }

		// buttons
		for (int i = 0; i < inputTypes.Length; ++i)
		{
			CheckButtonPressed(inputTypes[i]);
		}
	}

	void CheckButtonPressed(InputType type)
	{
		if (null == inputs[type].action)
		{
			return;
		}

		#if UNITY_EDITOR
		if (string.IsNullOrEmpty(inputs[type].identifier))
		{
			Debug.LogError("Missing input name for " + inputs[type].action.ToString());
			return;
		}
		#endif

		if (Input.GetButtonDown(inputs[type].identifier))
		{
			inputs[type].action();
			#if UNITY_EDITOR
			if (logButtonEvents) Debug.LogError(inputs[type].identifier + " pressed");
			#endif
		}
	}

		// // triggers
		// if (Input.GetAxis("Xbox L. Trigger") > 0.001f)
		// {
		// 	if (!_triggerLeft)
		// 	{
		// 		if (logButtonEvents) Debug.LogError("xbox l. trigger");
		// 	}
		// 	else
		// 	{
		// 		// do something
		// 	}
		// 	if (debugTriggers) Debug.LogError("xbox l. trigger " + Input.GetAxis("Xbox L. Trigger"));
		// }
		// _triggerLeft = Input.GetAxis("Xbox L. Trigger") > 0.001f;
		// if (Input.GetAxis("Xbox R. Trigger") > 0.001f)
		// {
		// 	if (!_triggerRight)
		// 	{
		// 		if (logButtonEvents) Debug.LogError("xbox r. trigger");
		// 	}
		// 	else
		// 	{
		// 		// do something
		// 	}
		// 	if (debugTriggers) Debug.LogError("xbox r. trigger " + Input.GetAxis("Xbox R. Trigger"));
		// }
		// _triggerRight = Input.GetAxis("Xbox R. Trigger") > 0.001f;

		// // dpad left
		// if (Input.GetAxis("Xbox Dpad Vertical") > 0.001f)
		// {
		// 	if (!_dpadUp) // on first press
		// 	{
		// 		if (logButtonEvents) Debug.LogError("xbox u. dpad");
		// 	}
		// 	else // held
		// 	{
		// 		// do something
		// 	}
		// }
		// _dpadUp = Input.GetAxis("Xbox Dpad Vertical") > 0.001f;

		// // dpad down
		// if (Input.GetAxis("Xbox Dpad Vertical") < -0.001f)
		// {
		// 	if (!_dpadDown) // on first press
		// 	{
		// 		if (logButtonEvents) Debug.LogError("xbox d. dpad");
		// 	}
		// 	else // held
		// 	{
		// 		// do something
		// 	}
		// }
		// _dpadDown = Input.GetAxis("Xbox Dpad Vertical") < -0.001f;

		// // dpad left
		// if (Input.GetAxis("Xbox Dpad Horizontal") < -0.001f)
		// {
		// 	if (!_dpadLeft) // on first press
		// 	{
		// 		if (logButtonEvents) Debug.LogError("xbox l. dpad");
		// 	}
		// 	else // held
		// 	{
		// 		// do something
		// 	}
		// }
		// _dpadLeft = Input.GetAxis("Xbox Dpad Horizontal") < -0.001f;

		// // dpad right
		// if (Input.GetAxis("Xbox Dpad Horizontal") > 0.001f)
		// {
		// 	if (!_dpadRight) // on first press
		// 	{
		// 		if (logButtonEvents) Debug.LogError("xbox r. dpad");
		// 	}
		// 	else // held
		// 	{
		// 		// do something
		// 	}
		// }
		// _dpadRight = Input.GetAxis("Xbox Dpad Horizontal") > 0.001f;
}
