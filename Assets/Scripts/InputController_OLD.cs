// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour {

// 	public bool debugButtons;
// 	public bool debugJoysticks;
// 	public bool debugTriggers;
// 	public float movementSpeed;

// 	private GameObject _player;
// 	private Camera _camera;
// 	private Vector3 _positionDelta;
// 	private bool _a;
// 	private bool _b;
// 	private bool _x;
// 	private bool _y;
// 	private bool _back;
// 	private bool _start;
// 	private bool _joystickLeft;
// 	private bool _joystickRight;
// 	private bool _bumperLeft;
// 	private bool _bumperRight;
// 	private bool _triggerLeft;
// 	private bool _triggerRight;
// 	private bool _dpadUp;
// 	private bool _dpadDown;
// 	private bool _dpadLeft;
// 	private bool _dpadRight;

// 	// Use this for initialization
// 	void Start () {
// 		_player = this.gameObject;
// 		if (null == _player)
// 		{
// 			Debug.LogError("_player is null");
// 		}
// 		_camera = Camera.main;
// 		if (null == _camera)
// 		{
// 			Debug.LogError("_camera is null");
// 		}
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
// 		_positionDelta = _camera.transform.forward * Input.GetAxis("Xbox L. Joystick Vertical") + _camera.transform.right * Input.GetAxis("Xbox L. Joystick Horizontal");
// 		_positionDelta.y = 0;
// 		this.transform.Translate(_positionDelta * movementSpeed * Time.deltaTime, Space.World);
// 		if (_positionDelta != Vector3.zero)
// 		{
// 			this.transform.rotation = Quaternion.LookRotation(_positionDelta);
// 		}
		
// 		// joysticks
// 		if (Input.GetAxis("Xbox L. Joystick Vertical") < -0.001f || 0.001f < Input.GetAxis("Xbox L. Joystick Vertical") || Input.GetAxis("Xbox L. Joystick Horizontal") < -0.001f || 0.001f < Input.GetAxis("Xbox L. Joystick Horizontal"))
// 		{
// 			if (debugJoysticks) Debug.LogError("xbox l. joystick (" + Input.GetAxis("Xbox L. Joystick Vertical") + ", " + Input.GetAxis("Xbox L. Joystick Horizontal"));
// 		}
// 		if (Input.GetAxis("Xbox R. Joystick Vertical") < -0.001f || 0.001f < Input.GetAxis("Xbox R. Joystick Vertical") || Input.GetAxis("Xbox R. Joystick Horizontal") < -0.001f || 0.001f < Input.GetAxis("Xbox R. Joystick Horizontal"))
// 		{
// 			if (debugJoysticks) Debug.LogError("xbox r. joystick vertical " + Input.GetAxis("Xbox R. Joystick Vertical") + ", " + Input.GetAxis("Xbox R. Joystick Horizontal"));
// 		}

// 		// buttons
// 		_a = Input.GetButtonDown("Xbox A");
// 		if (_a)
// 		{
// 			if (debugButtons) Debug.LogError("xbox a");
// 		}
// 		_b = Input.GetButtonDown("Xbox B");
// 		if (_b)
// 		{
// 			if (debugButtons) Debug.LogError("xbox b");
// 		}
// 		_x = Input.GetButtonDown("Xbox X");
// 		if (_x)
// 		{
// 			if (debugButtons) Debug.LogError("xbox x");
// 		}
// 		_y = Input.GetButtonDown("Xbox Y");
// 		if (_y)
// 		{
// 			if (debugButtons) Debug.LogError("xbox y");
// 		}
// 		_back = Input.GetButtonDown("Xbox Back");
// 		if (_back)
// 		{
// 			if (debugButtons) Debug.LogError("xbox back");
// 		}
// 		_start = Input.GetButtonDown("Xbox Start");
// 		if (_start)
// 		{
// 			if (debugButtons) Debug.LogError("xbox start");
// 		}
// 		_joystickLeft = Input.GetButtonDown("Xbox L. Joystick");
// 		if (_joystickLeft)
// 		{
// 			if (debugButtons) Debug.LogError("xbox l. joystick");
// 		}
// 		_joystickRight = Input.GetButtonDown("Xbox R. Joystick");
// 		if (_joystickRight)
// 		{
// 			if (debugButtons) Debug.LogError("xbox r. joystick");
// 		}

// 		// Bumpers
// 		_bumperLeft = Input.GetButtonDown("Xbox L. Bumper");
// 		if (_bumperLeft)
// 		{
// 			if (debugButtons) Debug.LogError("xbox l. bumper");
// 		}
// 		_bumperRight = Input.GetButtonDown("Xbox R. Bumper");
// 		if (_bumperRight)
// 		{
// 			if (debugButtons) Debug.LogError("xbox r. bumper");
// 		}

// 		// triggers
// 		if (Input.GetAxis("Xbox L. Trigger") > 0.001f)
// 		{
// 			if (!_triggerLeft)
// 			{
// 				if (debugButtons) Debug.LogError("xbox l. trigger");
// 			}
// 			else
// 			{
// 				// do something
// 			}
// 			if (debugTriggers) Debug.LogError("xbox l. trigger " + Input.GetAxis("Xbox L. Trigger"));
// 		}
// 		_triggerLeft = Input.GetAxis("Xbox L. Trigger") > 0.001f;
// 		if (Input.GetAxis("Xbox R. Trigger") > 0.001f)
// 		{
// 			if (!_triggerRight)
// 			{
// 				if (debugButtons) Debug.LogError("xbox r. trigger");
// 			}
// 			else
// 			{
// 				// do something
// 			}
// 			if (debugTriggers) Debug.LogError("xbox r. trigger " + Input.GetAxis("Xbox R. Trigger"));
// 		}
// 		_triggerRight = Input.GetAxis("Xbox R. Trigger") > 0.001f;

// 		// dpad left
// 		if (Input.GetAxis("Xbox Dpad Vertical") > 0.001f)
// 		{
// 			if (!_dpadUp) // on first press
// 			{
// 				if (debugButtons) Debug.LogError("xbox u. dpad");
// 			}
// 			else // held
// 			{
// 				// do something
// 			}
// 		}
// 		_dpadUp = Input.GetAxis("Xbox Dpad Vertical") > 0.001f;

// 		// dpad down
// 		if (Input.GetAxis("Xbox Dpad Vertical") < -0.001f)
// 		{
// 			if (!_dpadDown) // on first press
// 			{
// 				if (debugButtons) Debug.LogError("xbox d. dpad");
// 			}
// 			else // held
// 			{
// 				// do something
// 			}
// 		}
// 		_dpadDown = Input.GetAxis("Xbox Dpad Vertical") < -0.001f;

// 		// dpad left
// 		if (Input.GetAxis("Xbox Dpad Horizontal") < -0.001f)
// 		{
// 			if (!_dpadLeft) // on first press
// 			{
// 				if (debugButtons) Debug.LogError("xbox l. dpad");
// 			}
// 			else // held
// 			{
// 				// do something
// 			}
// 		}
// 		_dpadLeft = Input.GetAxis("Xbox Dpad Horizontal") < -0.001f;

// 		// dpad right
// 		if (Input.GetAxis("Xbox Dpad Horizontal") > 0.001f)
// 		{
// 			if (!_dpadRight) // on first press
// 			{
// 				if (debugButtons) Debug.LogError("xbox r. dpad");
// 			}
// 			else // held
// 			{
// 				// do something
// 			}
// 		}
// 		_dpadRight = Input.GetAxis("Xbox Dpad Horizontal") > 0.001f;
// 	}
// }
